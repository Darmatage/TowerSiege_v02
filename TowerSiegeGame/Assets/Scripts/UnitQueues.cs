/*
 * Hold unit objects in a list of queues.
 * Keep this script attached to the GameController object and set Queue Count to the number of spawn points.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitQueues : MonoBehaviour
{
    public int queueCount;

    private List<Queue<GameObject>> unitQueues;
    private TextMeshProUGUI[] unitCountTexts;
    private GameObject selectedUnit;
    private List<int> moneySpent;

    // Start is called before the first frame update
    void Start()
    {
        unitCountTexts = GameObject.Find("Canvas/UnitCountTexts").GetComponentsInChildren<TextMeshProUGUI>();
        unitQueues = new List<Queue<GameObject>>();
        moneySpent = new List<int>();
        for (int i = 0; i < queueCount; i++)
        {
            unitQueues.Add(new Queue<GameObject>());
            moneySpent.Add(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update the unit count texts.
        for (int i = 0; i < queueCount; i++)
        {
            unitCountTexts[i].SetText(unitQueues[i].Count.ToString());
        }
    }

    public void SelectUnit(GameObject selectedUnit)
    {
        this.selectedUnit = selectedUnit;
    }

    public GameObject GetSelected()
    {
        return selectedUnit;
    }

    public void Enqueue(int queueIndex, GameObject unit)
    {
        unitQueues[queueIndex].Enqueue(selectedUnit);
        moneySpent[queueIndex] += unit.GetComponent<Unit>().cost;
    }

    public GameObject Dequeue(int queueIndex)
    {
        return unitQueues[queueIndex].Dequeue();
    }

    public bool IsEmpty(int queueIndex)
    {
        return unitQueues[queueIndex].Count == 0;
    }

    public bool UnitsQueued()
    {
        for (int i = 0; i < queueCount; i++)
        {
            if (!IsEmpty(i))
            {
                return true;
            }
        }

        return false;
    }

    public void Reset(){
        gameObject.GetComponent<Money>().CollectMoney(moneySpent[0]);
        moneySpent[0] = 0;
        unitQueues = new List<Queue<GameObject>>();
        for (int i = 0; i < queueCount; i++)
        {
            unitQueues.Add(new Queue<GameObject>());
        }
    }

    public void SpecificReset(int queueIndex){
        gameObject.GetComponent<Money>().CollectMoney(moneySpent[queueIndex]);
        moneySpent[queueIndex] = 0;
        unitQueues[queueIndex] = new Queue<GameObject>();
    }
}