using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCommon : MonoBehaviour
{
    public GameObject Player;
    private void OnCollisionEnter(Collision collision)
    {
        Player.GetComponent<HealthSystem>().TakeDamage();
    }
}
