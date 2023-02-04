using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanSpawner : MonoBehaviour
{
    public GameObject rightBean;
    public GameObject leftBean;
    public GameObject player;
    public Transform spawnPoint;
    public Vector3 lastSpawnPos;
    private float zRotation;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBean();
        }
    }

    void Start()
    {
        lastSpawnPos = spawnPoint.position;
        zRotation = 0f;
    }

    void SpawnBean()
    {
        Vector3 spawnPos = lastSpawnPos;
        Collider2D collider = Physics2D.OverlapCircle(spawnPos, 0.1f);
        while (collider != null)
        {
            spawnPos.y += 1f;
            collider = Physics2D.OverlapCircle(spawnPos, 0.1f);
        }

        if (player.transform.position.x > spawnPoint.position.x)
        {
            spawnPos.y += 10f;
            spawnPos.x += 20f;
            zRotation -= 10f;
            Instantiate(rightBean, spawnPos, Quaternion.Euler(0f, 0f, zRotation));
        }
        else
        {
            spawnPos.y += 20f;
            spawnPos.x -= 10f;
            zRotation = 0f;
            Instantiate(leftBean, spawnPos, Quaternion.Euler(0f, 0f, zRotation));
        }

        lastSpawnPos = spawnPos;
    }
}
