using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource m_Source;
    [SerializeField] AudioSource m_SFX;

    public AudioClip m_background;
    public AudioClip nefati_atk;
    public AudioClip player_jump;
    public AudioClip player_takeHit;
    public AudioClip Boss_atk;

    private void Start()
    {
        m_Source.clip = m_background;
        m_Source.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        m_SFX.PlayOneShot(clip);
    }
}

