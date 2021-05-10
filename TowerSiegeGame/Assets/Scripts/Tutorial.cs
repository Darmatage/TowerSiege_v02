using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public static bool isTutorial = true;
    public GameObject scrollUI;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
		scrollUI.SetActive(true);
        Time.timeScale = 0f;
        isTutorial = true;
        player.GetComponent<Player>().Freeze();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTutorial) {
            if (Input.anyKeyDown) {
                Resume();
            }
        } else {
            this.enabled = false;
        }
    }

    public void Resume()
    {
        scrollUI.SetActive(false);
        Time.timeScale = 1f;
        isTutorial = false;
        player.GetComponent<Player>().Unfreeze();
    }

}