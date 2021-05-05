using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackoutLevels : MonoBehaviour
{
	static public int currentLevel;
    public int level;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag != "Button") return;
        if(currentLevel >= level) button.interactable = true;
        else button.interactable = false;
    }

    public void defeatedLevel(){
        currentLevel++;
    }

    public void unlockAllLevels(){
        currentLevel = 20;
    }
}
