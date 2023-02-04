using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafAnimScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<Animation>().Play();
    }
}
