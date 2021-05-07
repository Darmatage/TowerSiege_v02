using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;


public class ToffleSFX : MonoBehaviour
{
	public static bool toggleSFX = true;
	public Toggle sfxToggle;
	private GameObject[] sfx;
	private List<AudioSource> audioSources = new List<AudioSource>();
	int id;
    // Start is called before the first frame update
    void Start()
    {
        sfxToggle.isOn = toggleSFX;
        sfx = GameObject.FindGameObjectsWithTag("SFX");
        foreach (GameObject currAudio in sfx) 
        {
        	audioSources.Add(currAudio.GetComponent<AudioSource>());
        }
    }

    // Update is called once per frame
    void Update()
    {
    	foreach (AudioSource audio in audioSources) 
        {
            if(toggleSFX) audio.volume = 1;
            else audio.volume = 0;
        }
    }

    public void toggleSFXon(bool value) {
    	toggleSFX = !toggleSFX;
    }
}
