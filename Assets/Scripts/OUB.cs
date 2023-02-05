using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;

public class OUB : MonoBehaviour
{
    public GameObject GameOverUI;
    LayerMask Bean;

    private void Start()
    {
        GameOverUI.SetActive(false);
        Bean = LayerMask.NameToLayer("BeanLayer");
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == Bean)
        {
            Time.timeScale = 0;
            GameOverUI.SetActive(true);
        }

    }

    
}
