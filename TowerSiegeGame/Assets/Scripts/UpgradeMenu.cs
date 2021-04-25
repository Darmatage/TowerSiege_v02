using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeMenu : MonoBehaviour
{
	public static bool isActive = false;
	public GameObject upgradeMenuUI;
    public GameObject unitMenuUI;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeMenu() {
        if (isActive) {
            unitMenuUI.SetActive(true);
            upgradeMenuUI.SetActive(false);
            isActive = false;
        } else {
            upgradeMenuUI.SetActive(true);
            unitMenuUI.SetActive(false);
            isActive = true;
        }
    }

}