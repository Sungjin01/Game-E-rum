using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioClip soundArrow;
    public AudioClip soundAttack;
    public AudioClip soundJump;
    AudioSource myAudio;

    public static SoundManager instance;

    private void Awake()
    {
        if(SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }
    }

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        
    }

    public void PlayArrow()
    {
        myAudio.PlayOneShot(soundArrow);
    }
    public void PlayAttack()
    {
        myAudio.PlayOneShot(soundAttack);
    }
    public void PlayJump()
    {
        myAudio.PlayOneShot(soundJump);
    }

}
