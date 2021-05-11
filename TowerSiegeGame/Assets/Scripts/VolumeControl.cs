using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
	private GameObject[] audios;
	private List<AudioSource> audioSources = new List<AudioSource>();
    public static float volume = 0.2f;
	public Slider volumeSlider;


    void Start()
    {
        audios = GameObject.FindGameObjectsWithTag("Audio");
        foreach (GameObject currAudio in audios)
        {
        	audioSources.Add(currAudio.GetComponent<AudioSource>());
        }
        volumeSlider.value = volume;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (AudioSource audio in audioSources)
        {
            audio.volume = volume;
        }
    }

    // On value changed: Update the volume.
    public void ChangeVolume()
    {
        volume = volumeSlider.value;
    }
}
