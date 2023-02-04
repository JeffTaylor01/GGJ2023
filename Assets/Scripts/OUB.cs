using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;

public class OUB : MonoBehaviour
{
    public GameObject GameOverUI;

    private void Start()
    {
        GameOverUI.SetActive(false);
       GameOverUI = GameObject.Find("GameOverUI");
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            GameOverUI.SetActive(true);
        }

    }

    
}
