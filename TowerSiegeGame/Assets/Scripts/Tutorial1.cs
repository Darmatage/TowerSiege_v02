using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Tutorial1 : MonoBehaviour
{
    public static bool isTutorial;
    public GameObject scrollUI;
    private GameObject player;

    void Start()
    {
        isTutorial = true;
        player = GameObject.FindGameObjectWithTag("Player");
		scrollUI.SetActive(true);
        Time.timeScale = 0f;
        player.GetComponent<Player>().Freeze();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTutorial) {
            if (Input.anyKeyDown) {
                Finish();
            }
        } else {
            this.enabled = false;
        }
    }

    private void Finish()
    {
        scrollUI.SetActive(false);
        Time.timeScale = 1f;
        isTutorial = false;
        player.GetComponent<Player>().Unfreeze();
    }

}