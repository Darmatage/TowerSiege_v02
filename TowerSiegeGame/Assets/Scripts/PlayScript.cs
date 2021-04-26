using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame() {
        Time.timeScale = 1f;
    	SceneManager.LoadScene("LevelMenu");
    }

    public void PlayLevel0()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level0_Tutorial");
    }

    public void PlayLevel1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void PlayLevel2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void PlayLevel3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void PlayLevel4()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void PlayLevel5()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void PlayLevel6()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void PlayLevel7()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void PlayLevel8()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void PlayLevel9()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void PlayLevel10()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame() {
    	Application.Quit();
    }
}
