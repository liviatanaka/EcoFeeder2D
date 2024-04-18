using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("--------- Audio Sources --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip -----------")]

    public AudioClip background;
    public AudioClip coracao;
    public AudioClip dano;
    public AudioClip abelha;
    public AudioClip rinoceronte;
    public AudioClip galinha;
    public AudioClip porco;
    public AudioClip pato;
    public AudioClip flecha;


    public AudioClip vitoria;
    public AudioClip morte;


    private void Start(){
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic(){
        musicSource.Stop();
    }

    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }

    public void StopSFX(){
        SFXSource.Stop();
        SFXSource.Play();

    }

    public AudioClip getClip(String objectTag){
        switch(objectTag){
            case "Abelha":
                return abelha;
            case "Rino":
                return rinoceronte;
            case "Galinha":
                return galinha;
            case "Porco":
                return porco;
            case "Pato":
                return pato;
            default:
                return null;
        }

    }

}