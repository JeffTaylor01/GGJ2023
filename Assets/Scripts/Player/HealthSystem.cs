using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour, IAudible
{
    public Vector3 RespawnLoc;
    public int MaxHealth;
    public int Health;
    public GameObject[] Hearts;
    public GameObject LoseScreen;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public AudioSource audioSource;
    bool takingDamaging = false;
    void Start()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            Hearts[i].GetComponent<Image>().sprite = FullHeart;
        }
        Health = 3;
        MaxHealth = 3;

        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (gameObject.transform.position.y < RespawnLoc.y && RespawnLoc.y > 0)
        {
            TakeDamage();
        }

        if(Health <= 0)
        {
            LoseScreen.SetActive(true);
        }
    }

    public void TakeDamage()
    {
        if (Health > 0)
        {
            Hearts[Health - 1].GetComponent<Image>().sprite = EmptyHeart;
            Health -= 1;
            PlaySoundEffect(audioSource);
        }
    }


    public void PlaySoundEffect(AudioSource soundEffectSource)
    {
        soundEffectSource.Play();
    }
}
