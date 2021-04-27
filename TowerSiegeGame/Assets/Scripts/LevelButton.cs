/*
 * Launch a level scene from the level menu.
 * Attach this script to a level button and set the level number field.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public int levelNumber;

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

    // On-click: Play the level.
    public void PlayLevel()
    {
        gameController.GetComponent<PlayScript>().PlayLevel(levelNumber);
    }
}
