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
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public AudioSource audioSource;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        Hearts[Health - 1].GetComponent<Image>().sprite = EmptyHeart;
        Health -= 1;
        PlaySoundEffect(audioSource);
    }

    public void PlaySoundEffect(AudioSource soundEffectSource)
    {
        soundEffectSource.Play();
    }
}
