using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BeanRotation : MonoBehaviour
{
    public Transform player;
    public float globalAngle;
    public float rotationSpeed;
    public BeanGrowth beanGrowth;

    private void FixedUpdate()
    {
        Transform lastBean = beanGrowth.LastBean.transform;

        if (player.position.x > lastBean.position.x)
        {
            globalAngle -= rotationSpeed;
        }
        else
        {
            globalAngle += rotationSpeed;
        }
        /*
        if (globalAngle < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 0.1f);
        }
        else if (globalAngle > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 0.1f);
        }
        */
    }
}