using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource musicAudioShource;
    public AudioSource vfxAudioShource;

    public AudioClip musicClip;
 
    void Start()
    {
        musicAudioShource.clip = musicClip;
        musicAudioShource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
