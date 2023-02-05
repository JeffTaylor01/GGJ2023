using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowUI : MonoBehaviour
{
    public PlayerJump playerJump;
    public Slider arrowSlider;
    public Image fill;
    public Gradient gradient;

    [Header("JumpingUI")]
    public GameObject jumpArrow;
    GameObject player;

    Camera camera;
    public float smoothness = 10f;

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
        fill.color = gradient.Evaluate(0f);
    }

    private void SetSliderValue(float currentJumpPower)
    {
        arrowSlider.value = currentJumpPower;
        fill.color = gradient.Evaluate(arrowSlider.normalizedValue);
    }

    private void RotateArrow()
    {
        Vector3 arrowDirection = playerJump.JumpDirection;
        arrowDirection.z = 10f;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, arrowDirection);
        jumpArrow.transform.rotation = Quaternion.Lerp(jumpArrow.transform.rotation, targetRotation, Time.deltaTime * smoothness);
    }
}
