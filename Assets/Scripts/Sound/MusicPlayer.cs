using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public AudioClip[] musicTracks;
    AudioSource audioData;

    void Start() {
        audioData = GetComponent<AudioSource>();
    }

    void Update() {
        if(!audioData.isPlaying) {
            audioData.clip = musicTracks[Random.Range(0, musicTracks.Length)];
            audioData.Play();
        }
    }
}
