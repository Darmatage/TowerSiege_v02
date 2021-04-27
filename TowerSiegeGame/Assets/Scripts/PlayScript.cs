using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public int levelsImplemented;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Load a level scene. Levels must be named with the convention "Level#".
    // Note: Loads MainScene by default if the level scene has not been implemented yet.
    public void PlayLevel(int levelNumber)
    {
        Time.timeScale = 1f;
        if (levelNumber < levelsImplemented)
        {
            SceneManager.LoadScene("Level" + levelNumber);
        }
        else
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public void PlayGame() 
    {
        Time.timeScale = 1f;
    	SceneManager.LoadScene("LevelMenu");
    }

    public void QuitGame() {
    	Application.Quit();
    }
}
