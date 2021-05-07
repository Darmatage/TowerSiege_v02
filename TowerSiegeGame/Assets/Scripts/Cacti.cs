using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacti : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Apply damage and destroy the projectile if it collides with a unit or the player.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
        if (collision.gameObject.tag == "Unit")
        {
            collision.gameObject.GetComponent<Unit>().TakeDamage(damage);
        }
    }
}
