using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    GameObject JumpDirMarker;
    [SerializeField]
    Camera camera;
    Vector3 MousePos;
    public Vector3 JumpDirection;
    public float JumpPower;
    public float jumpIncreaseRate;
    public float jumpPowerLimit;

    public bool isJumping;

    [Header("JumpingUI")]
    public GameObject jumpArrow;
    public SpriteRenderer jumpArrowUI;
    GameObject player;
    public Vector3 playerOffset;

    public float rotSpeed;
    void Start()
    {
        jumpIncreaseRate = 1;
        jumpPowerLimit = 15;

        Player = this.gameObject;
        camera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
        jumpArrowUI = jumpArrow.GetComponentInChildren<SpriteRenderer>();
        jumpArrowUI.enabled = false;
    }


    void Update()
    {
        Jump();
        RotateArrow(JumpDirection);
    }

    private void Jump()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        MousePos = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            jumpArrowUI.enabled = true;
            if (JumpPower <= jumpPowerLimit)
            {
                JumpPower += jumpIncreaseRate;
            }

            if (Physics.Raycast(ray, out hit))
            {
                JumpDirection = (hit.point - Player.transform.position).normalized;
                JumpDirection.z = 0;
                Debug.Log(JumpDirection);
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            jumpArrowUI.enabled = false;
            isJumping = false;
            Player.GetComponent<Rigidbody>().velocity = JumpPower * JumpDirection;
            JumpPower = 0;
        }
    }
    private void RotateArrow(Vector3 rotationDirection)
    {
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(0, 0, jumpArrow.transform.rotation.z), rotationDirection);
        jumpArrow.transform.rotation = Quaternion.RotateTowards(jumpArrow.transform.rotation, lookRotation, rotSpeed * Time.deltaTime);
    }
}
