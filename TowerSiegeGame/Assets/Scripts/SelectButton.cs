/*
 * Select a unit to buy.
 * Attach this script to a Set[unit type] object and drag the appropriate prefab onto the inspector field.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectButton : MonoBehaviour
{
    public GameObject unit;


    private GameObject gameController;
    private GameObject startRoundButton;
    private Image[] allButtons;
    private bool selected;

    // Start is called before the first frame update
    void Start()
    {
    	// print(unit.GetComponent<Unit>().health);
    	this.transform.Find("CostText").gameObject.GetComponent<TextMeshProUGUI>().text = (unit.GetComponent<Unit>().cost).ToString();
    	this.transform.Find("HealthText").gameObject.GetComponent<TextMeshProUGUI>().text = (unit.GetComponent<Unit>().health).ToString();
    	this.transform.Find("SpeedText").gameObject.GetComponent<TextMeshProUGUI>().text = (unit.GetComponent<Unit>().speed).ToString();
    	this.transform.Find("DamageText").gameObject.GetComponent<TextMeshProUGUI>().text = (unit.GetComponent<Unit>().damage).ToString();
    	//print(unit.name);
        gameController = GameObject.FindGameObjectWithTag("GameController");
        startRoundButton = transform.parent.Find("StartRoundButton").gameObject;
        allButtons = transform.parent.GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // Grey out button if unit is too expensive.
        if (!gameController.GetComponent<Money>().CanAfford(unit))
        {
            gameObject.GetComponent<Image>().color = Color.gray;
        }
        else if (!selected)
        {
            gameObject.GetComponent<Image>().color = Color.white;
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.green;
        }
    }

    // On-click: Set the selected unit in UnitQueues and update the button colors.
    public void SelectUnit()
    {
        gameController.GetComponent<UnitQueues>().SelectUnit(unit);

        foreach (Image image in allButtons)
        {
            // Do not modify the soldier bar or start round button.
            if (image.gameObject == transform.parent.gameObject || image.gameObject == startRoundButton)
            {
                continue;
            }
            image.color = Color.white;
            image.gameObject.GetComponent<SelectButton>().Deselect();
        }
        selected = true;
    }

    public void Deselect()
    {
        selected = false;
    }
}