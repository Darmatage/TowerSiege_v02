/*
 * Display the end menu.
 * Keep this script attached to the GameController object.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndMenu : MonoBehaviour
{
    public GameObject endMenu;
    public GameObject endText;

    private GameObject gameController;
    private GameObject castle;
    private GameObject player;
    public RoundTimer timer;
    public Money gold;
    private bool reloading;
    private int maxRound = 3;
    private int currentRound = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        castle = GameObject.FindGameObjectWithTag("Castle");
        player = GameObject.FindGameObjectWithTag("Player");
        reloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        // End the game if the castle is destroyed.
        if (!castle.activeSelf)
        {
            DisplayEndMenu("CONGRATULATIONS\nYou destroyed the castle.");
        }

        // End the game if the player dies.
        if (!player.activeSelf)
        {
            DisplayEndMenu("GAME OVER\nYou died.");
        }

        // End the game if the player otherwise lost.
        if (Lost())
        {
            DisplayEndMenu("GAME OVER\nYou did not seige the castle in time.");
        }
    }

    public void Retry()
    {
        reloading = true;
        Time.timeScale = 1f;
        player.GetComponent<Player>().Unfreeze();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Continue()
    {
        Debug.Log("Doesn't work yet");
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void LoadLevelSelect() {
        SceneManager.LoadScene("LevelMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Check if the player lost.
    private bool Lost()
    {
        if (!gameController.GetComponent<UnitQueues>().UnitsQueued() && !gameController.GetComponent<Money>().HasMoney())
        {
            GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
            if (units.Length == 0)
            {
                if (currentRound == maxRound)
                {
                    return true;
                }
                currentRound++;
                timer.Start();
                gold.Start();
            }
        }

        return false;
    }

    // Display the end menu and set the end text.
    private void DisplayEndMenu(string endMessage)
    {
        if (!reloading)
        {
            Time.timeScale = 0f;
            player.GetComponent<Player>().Freeze();
        }
        endMenu.SetActive(true);
        endText.GetComponent<TextMeshProUGUI>().SetText(endMessage);
    }
}