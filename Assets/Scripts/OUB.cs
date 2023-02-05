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
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Time.timeScale = 0;
            GameOverUI.SetActive(true);
        }

    }

    
}
