using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowUI : MonoBehaviour
{
    public PlayerJump playerJump;
    public Slider arrowSlider;

    [Header("JumpingUI")]
    public GameObject jumpArrow;
    GameObject player;

    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerJump = player.GetComponent<PlayerJump>();
        if (playerJump != null)
        {
            Debug.Log("found player");
        }
        arrowSlider = this.GetComponent<Slider>();
        SetSliderMax(playerJump.jumpPowerLimit);

        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        SetSliderValue(playerJump.JumpPower);
        RotateArrow();
    }

    private void SetSliderMax(float jumpPowerLimit)
    {
        arrowSlider.maxValue = jumpPowerLimit;
        arrowSlider.value = 0;
    }

    private void SetSliderValue(float currentJumpPower)
    {
        arrowSlider.value = currentJumpPower;
    }

    private void RotateArrow()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f; // distance from the camera
        Vector3 mouseWorldPos = camera.ScreenToWorldPoint(mousePos);
        Vector3 direction = (mouseWorldPos - jumpArrow.transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
        jumpArrow.transform.rotation = rotation;
    }
}
