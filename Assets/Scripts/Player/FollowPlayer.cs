using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Rigidbody playerRigidbody;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
        playerRigidbody.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, playerRigidbody.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
}
