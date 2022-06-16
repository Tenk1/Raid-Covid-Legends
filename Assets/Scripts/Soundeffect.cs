using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundeffect : MonoBehaviour
{
    private AudioLowPassFilter filter;
    private AudioSource audioSource;
    public AudioSource music;


    void Start()
    {
        music.Play();
        audioSource = GetComponent<AudioSource>();
        filter = GetComponent<AudioLowPassFilter>();
        filter.enabled = false;
    }


    void Update()
    {
        if (GameManager.m_GameState == GameState.gameOver || GameManager.m_GameState == GameState.gamePause)
        {
            filter.enabled = true;
            audioSource.pitch = 0.9f;

        }
        else
        {
            filter.enabled = false;
            audioSource.pitch = 1f;
        }
    }
}
