using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Castle : MonoBehaviour
{
    public int health;

    private TextMeshPro healthText;

    // Start is called before the first frame update
    void Start()
    {
        // Set the health text to the current health.
        healthText = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        healthText.SetText(health.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Take damage and deactivate if health falls below zero.
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthText.SetText(health.ToString());
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}