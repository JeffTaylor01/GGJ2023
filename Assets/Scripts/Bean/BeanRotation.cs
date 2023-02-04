using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanRotation : MonoBehaviour
{
    public Transform player;
    public float RotationSpeed;
    public float globalAngle;
    public float raycastLength;

    void FixedUpdate()
    {
        RaycastHit hitLeft, hitRight;
        Vector3 leftDirection = -player.right;
        Vector3 rightDirection = player.right;

        if (Physics.Raycast(player.position, leftDirection, out hitLeft, raycastLength) &&
            Physics.Raycast(player.position, rightDirection, out hitRight, raycastLength))
        {
            RaycastHit hit = hitLeft.distance < hitRight.distance ? hitLeft : hitRight;
            if (hit.collider.CompareTag("Bean"))
            {
                Vector3 direction = hit.transform.position - player.position;

                if (direction.x > 0)
                {
                    globalAngle += 0.07f;
                }

                if (direction.x < 0)
                {
                    globalAngle -= 0.07f;
                }
            }
        }
    }
}
