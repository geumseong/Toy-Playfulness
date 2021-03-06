﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;
    public static MusicManager Instance { get { return _instance; } }
    public AudioClip total;
    public AudioClip theme;

    private AudioSource audioSource;

    private void Awake()
    {

    }

    private void Start()
    {
        if (Instance != null)
        {
            Debug.Log("Destroying duplicate MusicManager");
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            StartCoroutine(ThemeCoroutine());
        }
    }

    private IEnumerator ThemeCoroutine()
    {
        audioSource.clip = total;
        audioSource.Play();
        yield return new WaitForSeconds(total.length);
        audioSource.clip = theme;
        audioSource.loop = true;
        audioSource.Play();
    }
}
