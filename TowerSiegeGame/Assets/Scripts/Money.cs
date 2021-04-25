/*
 * Keep track of the player's money.
 * Keep this script attatched to the GameController object.
 */

 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using TMPro;

 public class Money : MonoBehaviour
 {
 	public int money;
 	private int currentMoney = 0;

 	private TextMeshProUGUI moneyText;

    // Start is called before the first frame update
 	public void Start()
 	{
 		currentMoney += money;
 		moneyText = GameObject.Find("Canvas/MoneyText").GetComponent<TextMeshProUGUI>();
 	}

    // Update is called once per frame
 	void Update()
 	{
        // Update the money text.
 		moneyText.SetText(currentMoney.ToString());
 	}

    // Check if the player can afford purchasing a unit.
 	public bool CanAfford(GameObject unit)
 	{
 		if (unit.GetComponent<Unit>().cost > currentMoney)
 		{
 			return false;
 		}

 		return true;
 	}

    // Decrement money by the unit cost.
 	public void DeductFunds(GameObject unit)
 	{
 		currentMoney -= unit.GetComponent<Unit>().cost;
 	}

    // Check if the player has money.
 	public bool HasMoney()
 	{
 		if (currentMoney > 0)
 		{
 			return true;
 		}

 		return false;
 	}

 	public void CollectMoney(int amount)
 	{
 		currentMoney += amount;
 	}
 }