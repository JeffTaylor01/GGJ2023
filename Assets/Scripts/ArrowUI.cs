using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowUI : MonoBehaviour
{
    public GameObject jumpArrow;
    public SpriteRenderer jumpArrowUI;

    public float rotSpeed;

    public PlayerJump playerJump;
    // Start is called before the first frame update
    void Start()
    {
        jumpArrowUI = jumpArrow.GetComponent<SpriteRenderer>();
        jumpArrowUI.enabled = false;

        playerJump = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerJump>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateArrow(playerJump.JumpDirection);
    }
    private void RotateArrow(Vector3 rotationDirection)
    {
        if (playerJump.isJumping)
        {
            jumpArrowUI.enabled = true;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, rotationDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotSpeed * Time.deltaTime);
        }
        else
        {
            jumpArrowUI.enabled = false;
        }
    }
}
