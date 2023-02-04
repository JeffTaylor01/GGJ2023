using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanSpawner2 : MonoBehaviour
{
    public GameObject leftBean;
    public GameObject rightBean;
    public Transform spawnPoint;
    public Transform player;
    private GameObject lastInstantiatedBean;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBean();
        }
    }

    void SpawnBean()
    {
        GameObject newBean;
        Vector3 newPos = spawnPoint.position;

        if (player.position.x > spawnPoint.position.x)
        {
            newBean = Instantiate(rightBean, newPos, spawnPoint.rotation);
        }
        else
        {
            newBean = Instantiate(leftBean, newPos, spawnPoint.rotation);
        }

        if (lastInstantiatedBean != null)
        {
            Bounds lastBounds = lastInstantiatedBean.GetComponent<Renderer>().bounds;
            newPos.y = lastBounds.max.y;
            newBean.transform.position = newPos;

            Mesh mesh = newBean.GetComponent<MeshFilter>().mesh;
            Vector3[] vertices = mesh.vertices;
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].y += lastBounds.size.y;
            }
            mesh.vertices = vertices;
            mesh.RecalculateBounds();
        }

        lastInstantiatedBean = newBean;
    }
}
