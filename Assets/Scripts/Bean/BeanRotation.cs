using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanRotation : MonoBehaviour
{
    public Transform player;
    public float globalAngle;

    private void FixedUpdate()
    {
        if (player.position.x > transform.position.x)
        {
            globalAngle -= 0.05f;
        }
        else
        {
            globalAngle += 0.05f;
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
