using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }
    public AudioSource shootingChanell;
    public AudioSource reloadingScorpion;

   
    public AudioSource reloadingM4A1;

    public AudioClip M4A1Shot;
    public AudioClip ScorpionShot;

    public AudioSource emptyScorpion;

    public AudioSource throwablesChannel;
    public AudioClip grenadeSound;


    public AudioClip zombieWalking;
    public AudioClip zombieChase;
    public AudioClip zombieAttack;
    public AudioClip zombieHurt;
    public AudioClip zombieDeath;

    public AudioSource ZombieChannel;
    public AudioSource ZombieChannel2;

    public AudioSource playerChannel;
    public AudioClip playerHurt;
    public AudioClip playerDeath;

    public AudioClip gameOverMusic;



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayShootingSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.SkorpionVZ:
                shootingChanell.PlayOneShot(ScorpionShot); 
                break;
            case WeaponModel.M4A1:
                shootingChanell.PlayOneShot(M4A1Shot);
                break;
        }
    }

    public void PlayReloadSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.SkorpionVZ:
                reloadingScorpion.Play();
                break;
            case WeaponModel.M4A1:
                reloadingM4A1.Play();  
                break;
        }
    }
}
