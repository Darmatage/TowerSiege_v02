using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherArrow : MonoBehaviour
{
	private Vector3 target;
	public float speed;
    public GameObject archer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void MoveToCastle(Vector3 castle){
    	target = castle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            collision.gameObject.GetComponent<Tower>().TakeDamage(archer.GetComponent<Unit>().damage);
            Destroy(gameObject);
        }
    }


}
