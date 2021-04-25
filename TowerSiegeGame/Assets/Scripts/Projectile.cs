using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage;

    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        // Set the projectile to point at the target.
        transform.right = target - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Move toward the target until reaching its position.
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    // Set the target.
    public void setTarget(Vector3 target)
    {
        this.target = target;
    }

    // Apply damage and destroy the projectile if it collides with a unit or the player.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Unit")
        {
            collision.gameObject.GetComponent<Unit>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
