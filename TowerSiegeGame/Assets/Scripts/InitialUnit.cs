using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialUnit : MonoBehaviour
{
	public Button button;
    private bool started = false;
    // Start is called before the first frame update
    void Start()
    {
    	
    	//button.GetComponent<SelectButton>().unit = unit;
        //button.GetComponent<SelectButton>().SelectUnit();
    }

    // Update is called once per frame
    void Update()
    {
        if(started == false) {
            button.onClick.Invoke();
            started = true;
        }
    }
}
