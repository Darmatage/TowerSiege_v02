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

    // Start is called before the first frame update
    void Start()
    {
        unitCountTexts = GameObject.Find("Canvas/UnitCountTexts").GetComponentsInChildren<TextMeshProUGUI>();
        unitQueues = new List<Queue<GameObject>>();
        for (int i = 0; i < queueCount; i++)
        {
            unitQueues.Add(new Queue<GameObject>());
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

    public void Enqueue(int queueIndex)
    {
        unitQueues[queueIndex].Enqueue(selectedUnit);
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
}