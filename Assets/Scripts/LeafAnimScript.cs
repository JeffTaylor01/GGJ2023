using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafAnimScript : MonoBehaviour
{
    public GameObject player;
    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<Animation>().Play();
    }

    private void Update()
    {
        if(player.transform.position.y > gameObject.transform.position.y)
        {
            player.GetComponent<HealthSystem>().RespawnLoc = gameObject.transform.GetChild(1).transform.position;
        }
    }
}
