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
        jumpIncreaseRate = 0.5f;
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

        if (Input.GetMouseButton(0) && !isJumping)
        {
            //jumpArrowUI.enabled = true;
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

        if (Input.GetMouseButtonUp(0) && !isJumping)
        {
            //jumpArrowUI.enabled = false;
            isJumping = false;
            Player.GetComponent<Rigidbody>().velocity = JumpPower * JumpDirection;
            JumpPower = 0;
        }
    }
    private void RotateArrow(Vector3 rotationDirection)
    {
        Vector3 screenPos = camera.WorldToScreenPoint(Player.transform.position);
        Vector3 direction = (Input.mousePosition - screenPos).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        jumpArrow.transform.rotation = Quaternion.RotateTowards(jumpArrow.transform.rotation, rotation, rotSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        isJumping = true;
    }
}
