/*
 * Keep track of time left in the round.
 * Keep this script attached to the GameController object and set attributes as desired.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundTimer : MonoBehaviour
{
    public int time;

    //private TextMeshProUGUI timerText;
    private GameObject startRoundButton;
    private bool timerStarted;
    private float timeLeft;

    // Start is called before the first frame update
    public void Start()
    {
        //timerText = GameObject.Find("Canvas/TimerText").GetComponent<TextMeshProUGUI>();
        startRoundButton = GameObject.Find("Canvas/SelectionMenu/SoldierBar/StartRoundButton");

        timerStarted = false;
        timeLeft = time;
        SetTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                timeLeft = 0;
                //timerStarted = false;
            }
            SetTimerText();
        }
    }

    // On-click: Start the timer.
    public void StartTimer()
    {
        timerStarted = true;
        startRoundButton.GetComponent<Image>().color = Color.green;
        startRoundButton.GetComponent<Button>().interactable = false;
        //timerText.color = Color.yellow;
    }
    
    public bool RoundStarted()
    {
        return timerStarted;
    }

    public bool TimeUp()
    {
        if (timeLeft > 0)
        {
            return false;
        }
        else
        {
            return false; // this was true
        }
    }

    private void SetTimerText()
    {
        //timerText.SetText("Time: " + timeLeft.ToString("0"));
    }
}