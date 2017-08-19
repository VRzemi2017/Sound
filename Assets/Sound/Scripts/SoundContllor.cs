using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundContllor : MonoBehaviour {
  
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Pause();
    }

    private void UpDate()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Debug.Log("MusicStart");
            audio.UnPause();
        }
    }
}
