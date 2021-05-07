/*
 * Contain information about a unit.
 * Attach this script to a unit prefab and set attributes as desired.
 * Note: To add waypoints, follow the pattern in the hierarcy exactly. Units will traverse the waypoints in order.
 */

 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
// using TMPro;

 public class Unit : MonoBehaviour
 {
    public Image healthBar;
    public int health;
    public float speed;
    public int damage;
    public int cost;
    public float attackFreq;

    // private TextMeshPro healthText;
    private Vector2[] waypoints;
    private int spawnIndex;
    private int numWaypoints;
    private int waypointIndex;
    private float attackTimer;
    private int maxHealth;
    private float shootTimer;
    private float archerInterval = 1f;
    private int id;

    // Start is called before the first frame update
    void Start()
    {
        // Store the waypoint transform coordinates in waypoints[].
        numWaypoints = GameObject.Find("Waypoints" + spawnIndex).transform.childCount;
        waypoints = new Vector2[numWaypoints];
        for (int i = 0; i < numWaypoints; i++)
        {
            waypoints[i] = GameObject.Find("Waypoints" + spawnIndex + "/Waypoint" + i).transform.position;
        }

        waypointIndex = 0;
        maxHealth = health;
        attackTimer = attackFreq;
        shootTimer = Time.deltaTime;

        /* Set the health text.
        healthText = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        SetHealthText();
        */
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the unit if it has reached its last waypoint.
        if (waypointIndex == numWaypoints)
        {
            Destroy(gameObject);
            return;
        }

        // Get the current waypoint coordinates from waypoints[] and move toward them.
        Vector2 currWaypoint = waypoints[waypointIndex];

        if(gameObject.name.ToLower().Contains("archer")) {
            GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
            GameObject tower = null;
            bool inrange = false;
            foreach(GameObject t in towers) {
                if(t.GetComponent<Tower>().InRange(gameObject)) {
                    inrange = true;
                    tower = t;
                }
            }
            if(inrange) {
                if(Time.deltaTime > shootTimer) {
                    GameObject arrow = Instantiate(Resources.Load<GameObject>("archerArrow"));
                    arrow.transform.position = transform.position;
                    arrow.GetComponent<ArcherArrow>().MoveToCastle(tower.GetComponent<Tower>().transform.position);
                    shootTimer = archerInterval + Time.deltaTime;
                }
            }
            else {
                transform.position = Vector2.MoveTowards(transform.position, currWaypoint, speed * Time.deltaTime);
                shootTimer = Time.deltaTime;
            }
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, currWaypoint, speed * Time.deltaTime);
        }

        // Increment the current waypoint index if the current waypoint has been reached.
        if (transform.position.x == currWaypoint.x && transform.position.y == currWaypoint.y)
        {
            waypointIndex++;
        }

        // animator stuff
        // if (transform.position.x > 0) {
        //     GetComponent<Animator>().SetTrigger("Right");
        // } else if (transform.position.x < 0) {
        //     GetComponent<Animator>().SetTrigger("Left");
        // } else if (transform.position.y > 0) {
        //     GetComponent<Animator>().SetTrigger("Up");
        // } else {
        //     GetComponent<Animator>().SetTrigger("Down");
        // }
    }

    // Set the spawn index to determine which waypoints the unit follows.
    public void SetSpawnIndex(int index)
    {
        spawnIndex = index;
    }

    // Decrease the health of the unit and destroy if its health reaches or goes below zero.
    public void TakeDamage(int damage)
    {
        health -= damage;
        SetHealthBar();
        // SetHealthText();
        if (health <= 0)
        {  
        	GameObject coin = Resources.Load<GameObject>("coin");
        	int newCost = cost/2;
            coin.GetComponent<MoneyPickup>().spawnCoins(newCost, transform.position);
            Destroy(gameObject);
        }
    }

    // Increase the unit health.
    public void IncreaseHealth()
    {
        health *= 2;
        maxHealth *= 2;
        SetHealthBar();
        // SetHealthText();
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }

    /* Set the health text.
    private void SetHealthText()
    {
        healthText.SetText(health.ToString());
    }
    */

    private void SetHealthBar()
    {
        healthBar.fillAmount = (float)health / maxHealth;
    }

    // Inflict damage when touching a tower or the castle.
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else
        {
            if (collision.gameObject.tag == "Castle")
            {
                collision.gameObject.GetComponent<Castle>().TakeDamage(damage);
            }
            if (collision.gameObject.tag == "Tower")
            {
                collision.gameObject.GetComponent<Tower>().TakeDamage(damage);
            }
            attackTimer = attackFreq;
        }
    }
}