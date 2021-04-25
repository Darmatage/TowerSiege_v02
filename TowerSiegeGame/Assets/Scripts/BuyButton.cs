/* 
 * Buy units.
 * Attach this script to a BuyButton object and set Button Index appropriately.
 */

 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;

 public class BuyButton : MonoBehaviour
 {
    public int buttonIndex;

    private GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {

    }

    // On-click: Buy the selected unit.
    public void BuyUnit()
    {
        GameObject selectedUnit = gameController.GetComponent<UnitQueues>().GetSelected();
        if(selectedUnit != null) {
           if (gameController.GetComponent<Money>().CanAfford(selectedUnit))
           {
               gameController.GetComponent<UnitQueues>().Enqueue(buttonIndex);
               gameController.GetComponent<Money>().DeductFunds(selectedUnit);
           }
       }
   }
}