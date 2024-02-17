using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomsounds : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] sounds;
    void Start()
    {
        source = GetComponent<AudioSource>();
        int randomsound = Random.Range(0, sounds.Length);
        source.clip = sounds[randomsound];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
