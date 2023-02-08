using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafAnimScript : MonoBehaviour
{
    public GameObject player;
    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("LeafAnimScript: Could not find player with tag 'Player'");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<Animation>().Play();
    }

    private void Update()
    {
        if (player != null && player.transform.position.y > gameObject.transform.position.y)
        {
            HealthSystem healthSystem = player.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.RespawnLoc = gameObject.transform.GetChild(1).transform.position;
            }
            else
            {
                Debug.LogError("LeafAnimScript: Could not find HealthSystem component on player object");
            }
        }
    }
}
