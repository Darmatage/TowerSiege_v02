using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundAudio : MonoBehaviour
{
    
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("BackgroundMusic");
        if ( musicObj.Length > 1 )
        {
            Destroy( this.gameObject );
        }
        
        DontDestroyOnLoad( this.gameObject );
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name != "LevelMenu" &&
            SceneManager.GetActiveScene().name != "TitleScreen")
        {
            Destroy( this.gameObject );
        }
    }
}

// https://www.youtube.com/watch?v=ptkxRn0HCJc
