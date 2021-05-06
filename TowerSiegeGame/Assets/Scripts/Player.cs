using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// using TMPro;

public class Player : MonoBehaviour
{
	public Image healthBar;
	public int health;
	public float speed;
	public float buffCooldown;
	public float buffRange;
	public float debuffCooldown;
	public float debuffRange;
	public float debuffDuration;

	// private GameObject gameController;
	// private TextMeshPro healthText;
	// private TextMeshProUGUI buffText;
	// private TextMeshProUGUI debuffText;
	private Image debuffBar;
	private Image buffBar;
	private float buffTimer;
	private float debuffTimer;
	private bool buffReady;
	private bool debuffReady;
	private bool frozen;
	private int maxHealth;
	private int sceneNum;
	private int buffScene; //number scene where buff appears
	private int debuffScene; //number scene where debuff appears

	// Start is called before the first frame update
	void Start()
	{
		sceneNum = int.Parse(SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1));
		buffScene = 3;
		debuffScene = 4;
		// gameController = GameObject.FindGameObjectWithTag("GameController");
		// healthText = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
		// buffText = GameObject.Find("Canvas/BuffText").GetComponent<TextMeshProUGUI>();
		// debuffText = GameObject.Find("Canvas/DebuffText").GetComponent<TextMeshProUGUI>();

		if(sceneNum >= buffScene) buffBar = GameObject.Find("Canvas/BuffText/BuffBG/BuffBar").GetComponent<Image>();
		if(sceneNum >= debuffScene) debuffBar = GameObject.Find("Canvas/DebuffText/DebuffBG/DebuffBar").GetComponent<Image>();

		frozen = false;
		buffReady = true;
		debuffReady = true;
		buffTimer = 0f;
		debuffTimer = 0f;
		maxHealth = health;
		

		SetHealthBar();
		SetAbilityBars();

		// healthText.SetText(health.ToString());
		// SetBuffText();
		// SetDebuffText();
	}

	// Update is called once per frame
	void Update()
	{
		sceneNum = int.Parse(SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1));
		// SetBuffText();
		// SetDebuffText();
		SetAbilityBars();
		if (!frozen)
		{
			// Control the player's movement.
			if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			{
				//print("going left");
				Vector3 position = this.transform.position;
				position.x = position.x - speed;
				this.transform.position = position;
				
				// GetComponent<Animator>().SetTrigger("Left");
			}
			if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			{
				//print("going right");
				Vector3 position = this.transform.position;
				position.x = position.x + speed;
				this.transform.position = position;

				// GetComponent<Animator>().SetTrigger("Right");

			}
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			{
				//print("going up");
				Vector3 position = this.transform.position;
				position.y = position.y + speed;
				this.transform.position = position;

				// GetComponent<Animator>().SetTrigger("Up");

			}
			if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			{
				//print("going down");
				Vector3 position = this.transform.position;
				position.y = position.y - speed;
				this.transform.position = position;

				// GetComponent<Animator>().SetTrigger("Down");
			}

			// animator stuff
			// Vector2 dir = this.transform.position;
			// print(dir.x);
			// print(dir.y);
        	// GetComponent<Animator>().SetFloat("DirX", dir.x);
        	// GetComponent<Animator>().SetFloat("DirY", dir.y);

			// Buff cooldown.
			if (!buffReady)
			{
				if (buffTimer <= 0)
				{
					buffTimer = buffCooldown;
				}
				else
				{
					buffTimer -= Time.deltaTime;
					if (buffTimer <= 0)
					{
						buffReady = true;
					}
				}
			}

			// Debuff cooldown.
			if (!debuffReady)
            {
				if (debuffTimer <= 0)
                {
					debuffTimer = debuffCooldown;
				}
				else
                {
					debuffTimer -= Time.deltaTime;
					if (debuffTimer <= 0)
                    {
						debuffReady = true;
                    }
                }

            }

			// Use buff.
			
			if (Input.GetKey(KeyCode.Alpha2) && sceneNum >= buffScene)
			{

				if (buffReady)
				{
					Buff();
					buffReady = false;
				}
			}

			// Use debuff.
			if (Input.GetKey(KeyCode.Alpha1) && sceneNum >= debuffScene)
            {
				if (debuffReady)
                {
					Debuff();
					debuffReady = false;
				}
            }
		}
	}

	private void SetHealthBar()
    {
		healthBar.fillAmount = (float)health / maxHealth;
	}

	private void SetAbilityBars()
    {
		if(sceneNum >= buffScene) buffBar.fillAmount = (buffCooldown - buffTimer) / buffCooldown;
		if(sceneNum >= debuffScene) debuffBar.fillAmount = (debuffCooldown - debuffTimer) / debuffCooldown;
    }

	// Take damage and deactivate if health falls below zero.
	public void TakeDamage(int damage)
	{
		health -= damage;
		SetHealthBar();
		// healthText.SetText(health.ToString());
		if (health <= 0)
		{
			gameObject.SetActive(false);
		}
	}

	// Disable movement.
	public void Freeze()
	{
		frozen = true;
	}

	// Enable movement.
	public void Unfreeze()
	{
		frozen = false;
	}

	// Check if the game object is within range.
	private bool InRange(GameObject obj, float range)
	{
		Vector3 difference = obj.transform.position - transform.position;
		float distSqr = difference.sqrMagnitude;
		if (distSqr > range * range)
		{
			return false;
		}
		return true;
	}

	// Use the player buff ability.
	private void Buff()
	{
		GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
		foreach (GameObject unit in units)
		{
			if (InRange(unit, buffRange))
			{
				unit.GetComponent<Unit>().IncreaseHealth();
			}
		}
	}

	// Use the player debuff ability.
	private void Debuff()
    {
		GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
		foreach (GameObject tower in towers)
        {
			if (InRange(tower, debuffRange))
            {
				tower.GetComponent<Tower>().SlowShooting(debuffDuration);
            }
        }
    }

	/* Set the buff text.
	private void SetBuffText()
    {
		if (buffReady)
		{
			buffText.SetText("[2] READY");
		}
		else
        {
			buffText.SetText("[2] " + buffTimer.ToString("0") + "s");
        }
	}
	*/

	/* Set the debuff text.
	private void SetDebuffText()
    {
		if (debuffReady)
        {
			debuffText.SetText("[1] READY");
        }
		else
		{
			debuffText.SetText("[1] " + debuffTimer.ToString("0") + "s");
		}
	}
	*/
}