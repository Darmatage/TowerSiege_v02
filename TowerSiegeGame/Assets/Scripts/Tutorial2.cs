using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Tutorial2 : MonoBehaviour
{
    public static bool isTutorial;
    public GameObject scrollUI0;
    public GameObject scrollUI1;
    private GameObject player;
    private bool twoScrolls;

    void Start()
    {
        isTutorial = true;
        twoScrolls = true;
        player = GameObject.FindGameObjectWithTag("Player");
		scrollUI0.SetActive(true);
        scrollUI1.SetActive(false);
        Time.timeScale = 0f;
        player.GetComponent<Player>().Freeze();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTutorial) {
            if (Input.anyKeyDown) {
                if (twoScrolls)
                    Next();
                else
                    Finish();
            }
        } else {
            this.enabled = false;
        }
    }

    private void Next()
    {
        scrollUI0.SetActive(false);
        scrollUI1.SetActive(true);
        twoScrolls = false;
    }

    private void Finish()
    {
        scrollUI0.SetActive(false);
        scrollUI1.SetActive(false);
        Time.timeScale = 1f;
        isTutorial = false;
        player.GetComponent<Player>().Unfreeze();
    }

}