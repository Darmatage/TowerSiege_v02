using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
// using TMPro;

public class Tower : MonoBehaviour
{
    public Image healthBar;
    public GameObject projectile;
    public float interval;
    public float range;
    public float health;

    // private TextMeshPro healthText;
    private GameObject[] units;
    private GameObject target;
    private float shootTimer;
    private float debuffTimer;

    public Sprite[] towers;
    public SpriteRenderer spriteRenderer;
    private float original_health;

    // Start is called before the first frame update
    void Start()
    {
        // healthText = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();

        shootTimer = interval;
        debuffTimer = 0f;

        // healthText.SetText(health.ToString());
        // DrawCircle();

        original_health = health;
        SetHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        checkSprite();

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
            debuffTimer -= Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
            if (debuffTimer <= 0)
            {
                interval /= 2;
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        
    }

    private void checkSprite()
    {
        if ((health / original_health) == 1){
            spriteRenderer.sprite = towers[0];
        } else if ((health / original_health) > .92){
            spriteRenderer.sprite = towers[1];
        } else if ((health / original_health) > .84){
            spriteRenderer.sprite = towers[2];
        } else if ((health / original_health) > .76){
            spriteRenderer.sprite = towers[3];
        } else if ((health / original_health) > .68){
            spriteRenderer.sprite = towers[4];
        } else if ((health / original_health) > .60){
            spriteRenderer.sprite = towers[5];
        } else if ((health / original_health) > .52){
            spriteRenderer.sprite = towers[6];
        } else if ((health / original_health) > .44){
            spriteRenderer.sprite = towers[7];
        } else if ((health / original_health) > .36){
            spriteRenderer.sprite = towers[8];
        } else if ((health / original_health) > .28){
            spriteRenderer.sprite = towers[9];
        } else if ((health / original_health) > .20){
            spriteRenderer.sprite = towers[10];
        } else if ((health / original_health) > .12){
            spriteRenderer.sprite = towers[11];
        } else if ((health / original_health) > .8){
            spriteRenderer.sprite = towers[12];
        } else {
            spriteRenderer.sprite = towers[13];
        }
    }
    // Take damage when touched by a unit.
    public void TakeDamage(int damage)
    {
        health -= damage;
        SetHealthBar();
        // healthText.SetText(health.ToString());
        if (health <= 0)
        {
            GameObject coin = Resources.Load<GameObject>("coin");
            coin.GetComponent<MoneyPickup>().spawnCoins(300, transform.position);
            Destroy(gameObject);
        }
    }

    public void SetHealthBar()
    {
        healthBar.fillAmount = health / original_health;
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
