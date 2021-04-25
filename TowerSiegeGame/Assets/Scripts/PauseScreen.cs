using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
	public bool isPaused = false;
	public Sprite pause;
	public Sprite play;
	public Button pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseGame(){
    	if(isPaused) {
    		Time.timeScale = 1;
    		isPaused = false;
    	}
    	else {
    		Time.timeScale = 0;
    		isPaused = true;
    	}
    }

     public void ChangeImage(){
	     if (pauseButton.image.sprite == pause)
	         pauseButton.image.sprite = play;
	     else {
	         pauseButton.image.sprite = pause;
	     }
 	}
}
