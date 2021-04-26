using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
	private GameObject[] audios;
	private List<AudioSource> audioSources = new List<AudioSource>();
	public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        audios = GameObject.FindGameObjectsWithTag("Audio");
        foreach (GameObject currAudio in audios) {
        	audioSources.Add(currAudio.GetComponent<AudioSource>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (AudioSource audio in audioSources) {
        	audio.volume = volumeSlider.value;
        }
    }
}
