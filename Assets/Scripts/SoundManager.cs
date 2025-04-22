using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    private void OnEnable()
    {
        PlayerEvents.onHitEvent += PlayHitSound;
    }
    
    private void OnDisable()
    {
        PlayerEvents.onHitEvent -= PlayHitSound;
    }
    private void PlayHitSound()
    {
        source.PlayOneShot(clip);
    }
}
