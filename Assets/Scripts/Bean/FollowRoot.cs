using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRoot : MonoBehaviour
{
    public RootGrowth rootGrowthScript;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 newPosition = new Vector3(rootGrowthScript.LastRoot.transform.position.x, rootGrowthScript.LastRoot.transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
}
