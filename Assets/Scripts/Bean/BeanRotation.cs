using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanRotation : MonoBehaviour
{
    public Transform player;
    public float RotationSpeed;
    public float globalAngle;
    public float raycastLength;
    LayerMask BeanLayer;

    private void Start()
    {
        BeanLayer = LayerMask.NameToLayer("BeanLayer");
    }

    void FixedUpdate()
    {
        RaycastHit hitLeft, hitRight;
        Vector3 leftDirection = -player.right;
        Vector3 rightDirection = player.right;

        if (Physics.Raycast(player.position, leftDirection, out hitLeft, raycastLength))
        {
            if (hitLeft.collider.gameObject.layer == BeanLayer)
            {
                    globalAngle -= 0.2f;
            }
        }
        
        if (Physics.Raycast(player.position, rightDirection, out hitRight, raycastLength))
        {
            if (hitRight.collider.gameObject.layer == BeanLayer)
            {
                    globalAngle += 0.2f;
            }
        }
    }
}
