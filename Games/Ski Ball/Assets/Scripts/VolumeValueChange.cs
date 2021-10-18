using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValueChange : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 1f;

    //This allows Audio playing to continue uninterrupted while transitioning between scenes. 
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    //Volume controls
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    void Update()
    {
        audioSrc.volume = musicVolume;
    }
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}