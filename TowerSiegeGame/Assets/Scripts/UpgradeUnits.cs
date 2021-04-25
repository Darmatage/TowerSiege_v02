using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class UpgradeUnits : MonoBehaviour
{
    /*
    public Text unitCountText;
    public static GameObject currentUnitType;
    public List<GameObject> units = new List<GameObject>();

    public GameObject player;
    public GameObject vassal;
    public GameObject knight;
    public GameObject mercenary;
    public GameObject lancer;
    public GameObject footArcher;
    public GameObject artisan;
    public GameObject peasant;

    public Button vassalButton;
    public Button knightButton;
    public Button mercenaryButton;
    public Button lancerButton;
    public Button archerButton;
    public Button artisanButton;
    public Button peasantButton;

    public GameObject spawnPoint;
    public float interval;
    public int spawnIndex;

    private int unitCount;
    private bool spawning;
    private float timeRemaining;

    public GameObject startRound;
    public GameObject queueButton;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // units = GameObject.FindGameObjectWithTag("Unit");
    }

    // Update is called once per frame
    void Update()
    {

    }

    // public void upgradeSpeed()
    // {
    //     speed += 0.01f;
    // }
    //
    // public void upgradeHealth()
    // {
    //     health += 1;
    // }
    //
    // public void upgradeDamage()
    // {
    //     damage += 1;
    // }

    public void UpgradePlayer() {
        int unitCost = currentUnitType.GetComponent<Unit>().cost;
        bool unitBought = startRound.GetComponent<RoundTimer>().buyUnit(unitCost);
        if (unitBought)
        {
            units.Add(currentUnitType);
            queueButton.GetComponent<QueueUnit>().Queue();
        }
    }

    public void UpgradeVassal() {
        currentUnitType = vassal;
        vassalButton.GetComponent<Image>().color = Color.green;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        lancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void UpgradeKnight() {
        currentUnitType = knight;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.green;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        lancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void UpgradeMercenary() {
        currentUnitType = mercenary;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.green;
        lancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void Upgradelancer() {
        currentUnitType = lancer;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        lancerButton.GetComponent<Image>().color = Color.green;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void UpgradeArcher() {
        currentUnitType = footArcher;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        lancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.green;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void UpgradeArtisan() {
        currentUnitType = artisan;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        lancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.green;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void UpgradePeasant() {
        currentUnitType = peasant;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        lancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.green;
    }
    */
}