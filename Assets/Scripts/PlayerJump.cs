using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    GameObject JumpDirMarker;
    [SerializeField]
    Camera camera;
    Vector3 MousePos;
    Vector3 JumpDirection;
    float JumpPower;

    void Start()
    {

    }


    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        MousePos = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            JumpPower += 0.1f;

            if (Physics.Raycast(ray, out hit))
            {
                JumpDirection = (hit.point - Player.transform.position).normalized;
                JumpDirection.z = 0;
                Debug.Log(JumpDirection);
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            Player.GetComponent<Rigidbody>().velocity = JumpPower * JumpDirection;
        }

    }
}
