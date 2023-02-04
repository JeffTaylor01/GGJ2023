using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanRotation : MonoBehaviour
{
    public float globalAngle;
    public float RotationSpeed;
    public Transform player;

    GameObject AdjacentBean;

    void Start()
    {
        globalAngle = 0;
    }

    void Update()
    {
        AdjacentBean = GetAdjacentBean();

        if (AdjacentBean != null)
        {
            Vector3 direction = AdjacentBean.transform.position - player.position;
            globalAngle = -Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }

        Quaternion newRotation = Quaternion.Euler(0, 0, globalAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * RotationSpeed);
    }

    GameObject GetAdjacentBean()
    {
        GameObject[] Beans = GameObject.FindGameObjectsWithTag("Bean");
        foreach (GameObject Bean in Beans)
        {
            if (Vector3.Distance(Bean.transform.position, player.position) < 10)
            {
                return Bean;
            }
        }
        return null;
    }
}
