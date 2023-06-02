using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSourceMusicaDeFundo;
    public AudioClip[] musicasDeFundo;
    
    // Start is called before the first frame update
    void Start()
    {
        
        AudioClip musicaDeFundo = musicasDeFundo[1];
        audioSourceMusicaDeFundo.clip = musicaDeFundo;
        audioSourceMusicaDeFundo.loop = true;
        audioSourceMusicaDeFundo.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
