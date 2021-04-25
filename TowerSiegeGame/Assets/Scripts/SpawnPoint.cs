/*
 * Spawn units at the specified time interval.
 * Attach this script to a SpawnPoint Object and set Spawn Index approprately.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public int spawnIndex;
    public float interval;

    private GameObject gameController;
    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");

        spawnTimer = interval;
    }

    // Update is called once per frame
    void Update()
    {
        bool queueEmpty = gameController.GetComponent<UnitQueues>().IsEmpty(spawnIndex);
        bool roundStarted = gameController.GetComponent<RoundTimer>().RoundStarted();
        if (roundStarted && !queueEmpty)
        {
            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
            }
            else
            {
                GameObject unit = gameController.GetComponent<UnitQueues>().Dequeue(spawnIndex);
                GameObject unitClone = Instantiate(unit, transform.position, Quaternion.identity);
                unitClone.GetComponent<Unit>().SetSpawnIndex(spawnIndex);
                spawnTimer = interval;
            }
        }
    }
}