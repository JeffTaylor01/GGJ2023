using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Vector3 RespawnLoc;
    public int MaxHealth;
    public int Health;
    public GameObject[] Hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    void Start()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            Hearts[i].GetComponent<Image>().sprite = FullHeart;
        }
    }


    void Update()
    {
        
    }

    public void TakeDamage()
    {
        Hearts[Health - 1].GetComponent<Image>().sprite = EmptyHeart;
        Health -= 1;
    }
}
