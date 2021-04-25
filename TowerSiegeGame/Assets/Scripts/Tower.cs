using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using TMPro;

public class Tower : MonoBehaviour
{
    public GameObject projectile;
    public float interval;
    public float range;
    public int health;

    private TextMeshPro healthText;
    private GameObject[] units;
    private GameObject target;
    private float shootTimer;
    private float debuffTimer;

    // Start is called before the first frame update
    void Start()
    {
        healthText = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();

        shootTimer = interval;
        debuffTimer = 0f;

        healthText.SetText(health.ToString());
        // DrawCircle();
    }

    // Update is called once per frame
    void Update()
    {
        // Shoot the closest unit in range.
        units = GameObject.FindGameObjectsWithTag("Unit");
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        units = player.Concat(units).ToArray();
        if (units.Length == 0 || !InRange(ClosestUnit()))
        {
            shootTimer = interval;
        } 
        else if (shootTimer > 0)
        {
            if (target == null || !InRange(target))
            {
                target = ClosestUnit();
            }
            shootTimer -= Time.deltaTime;
        } 
        else
        {
            GameObject projectileClone = Instantiate(projectile, transform.position, Quaternion.identity);
            projectileClone.GetComponent<Projectile>().setTarget(target.transform.position);
            shootTimer = interval;
        }

        // Recieve a debuff.
        if (debuffTimer > 0)
        {
            Debug.Log("debuffed");
            debuffTimer -= Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
            if (debuffTimer <= 0)
            {
                interval /= 2;
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    // Take damage when touched by a unit.
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthText.SetText(health.ToString());
        if (health <= 0)
        {
            GameObject coin = Resources.Load<GameObject>("coin");
            coin.GetComponent<MoneyPickup>().spawnCoins(300, transform.position);
            Destroy(gameObject);
        }
    }

    // Slow the rate of fire.
    public void SlowShooting(float duration)
    {
        interval *= 2;
        debuffTimer = duration;
    }

    // Returns the closest unit to the tower (returns a null reference if no units are present).
    private GameObject ClosestUnit()
    {
        GameObject closest = null;
        float shortestDist = Mathf.Infinity;
        foreach (GameObject currUnit in units)
        {
            Vector3 difference = currUnit.transform.position - transform.position;
            float distance = difference.sqrMagnitude;
            if (distance < shortestDist)
            {
                closest = currUnit;
                shortestDist = distance;
            }
        }

        return closest;
    }

    // Check if a unit is within range.
    private bool InRange(GameObject unit)
    {
        Vector3 difference = unit.transform.position - transform.position;
        float distance = difference.sqrMagnitude;
        if (distance < range * range)
        {
            return true;
        }
        return false;
    }

    // Draw a circle around the tower to represent the range.
    private void DrawCircle()
    {
        int vertexNumber = 50;

        LineRenderer line = gameObject.GetComponent<LineRenderer>();
        line.material.color = Color.red;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.loop = true;
        float angle = 2 * Mathf.PI / vertexNumber;
        line.positionCount = vertexNumber;

        for (int i = 0; i < vertexNumber; i++)
        {
            Matrix4x4 rotationMatrix = new Matrix4x4(new Vector4(Mathf.Cos(angle * i), Mathf.Sin(angle * i), 0, 0),
                                                     new Vector4(-1 * Mathf.Sin(angle * i), Mathf.Cos(angle * i), 0, 0),
                                       new Vector4(0, 0, 1, 0),
                                       new Vector4(0, 0, 0, 1));
            Vector3 initialRelativePosition = new Vector3(0, range, 0);
            line.SetPosition(i, transform.position + rotationMatrix.MultiplyPoint(initialRelativePosition));
        }
    }
}
