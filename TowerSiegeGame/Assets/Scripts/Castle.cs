using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using TMPro;

public class Castle : MonoBehaviour
{
    public Image healthBar;
    public float health;

    // private TextMeshPro healthText;

    public Sprite[] castles;
    public SpriteRenderer spriteRenderer;
    private float original_health;

    // Start is called before the first frame update
    void Start()
    {
        // Set the health text to the current health.
        // healthText = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        // healthText.SetText(health.ToString());

        original_health = health;
        SetHealthBar();
    }

    private void checkSprite()
    {
        float curr_health = health / original_health;
        if (curr_health == 1){
            spriteRenderer.sprite = castles[0];
        } else if ((curr_health) > .93){
            spriteRenderer.sprite = castles[1];
        } else if ((curr_health) > .86){
            spriteRenderer.sprite = castles[2];
        } else if ((curr_health) > .79){
            spriteRenderer.sprite = castles[3];
        } else if ((curr_health) > .72){
            spriteRenderer.sprite = castles[4];
        } else if ((curr_health) > .65){
            spriteRenderer.sprite = castles[5];
        } else if ((curr_health) > .58){
            spriteRenderer.sprite = castles[6];
        } else if ((curr_health) > .51){
            spriteRenderer.sprite = castles[7];
        } else if ((curr_health) > .44){
            spriteRenderer.sprite = castles[8];
        } else if ((curr_health) > .37){
            spriteRenderer.sprite = castles[9];
        } else if ((curr_health) > .30){
            spriteRenderer.sprite = castles[10];
        } else if ((curr_health) > .23){
            spriteRenderer.sprite = castles[11];
        } else if ((curr_health) > .16){
            spriteRenderer.sprite = castles[12];
        } else if ((curr_health) > .9){
            spriteRenderer.sprite = castles[13];
        } else if ((curr_health) > .5){
            spriteRenderer.sprite = castles[14];
        } else {
            spriteRenderer.sprite = castles[15];
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkSprite();
    }

    // Take damage and deactivate if health falls below zero.
    public void TakeDamage(int damage)
    {
        health -= damage;
        SetHealthBar();
        if (health <= 0)
        {
            health = 0;
        }
        gameObject.GetComponent<Animator>().enabled = false;
    }

    private void SetHealthBar()
    {
        healthBar.fillAmount = health / original_health;
    }
}