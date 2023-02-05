using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine : MonoBehaviour
{
    public GameObject Player;
    private void OnCollisionEnter(Collision collision)
    {
        Player.GetComponent<HealthSystem>().TakeDamage();
        gameObject.GetComponent<Animator>().SetBool("BombHit", true);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject, 1);
    }
}
