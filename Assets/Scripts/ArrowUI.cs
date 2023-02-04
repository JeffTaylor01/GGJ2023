using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowUI : MonoBehaviour
{
    public PlayerJump playerJump;
    public Slider arrowSlider;
    // Start is called before the first frame update
    void Start()
    {
        playerJump = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerJump>();
        if(playerJump != null)
        {
            Debug.Log("found player");
        }
        arrowSlider = this.GetComponent<Slider>();
        SetSliderMax(playerJump.jumpPowerLimit);
    }

    // Update is called once per frame
    void Update()
    {
        SetSliderValue(playerJump.JumpPower);
        Debug.Log(playerJump.JumpPower);
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
}
