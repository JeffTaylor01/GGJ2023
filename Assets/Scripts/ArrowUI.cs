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

    public float rotSpeed;

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

        rotSpeed = 200;
        camera = Camera.main;
        //jumpArrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SetSliderValue(playerJump.JumpPower);
        //Debug.Log(playerJump.JumpPower);
        RotateArrow(playerJump.JumpDirection);
        //SpawnArrow();
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

    private void RotateArrow(Vector3 rotationDirection)
    {
        Vector3 screenPos = camera.WorldToScreenPoint(player.transform.position);
        Vector3 direction = (Input.mousePosition - screenPos).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        jumpArrow.transform.rotation = Quaternion.RotateTowards(jumpArrow.transform.rotation, rotation, rotSpeed * Time.deltaTime);
    }
   /* private void SpawnArrow()
    {
        if (Input.GetMouseButton(0))
        {
            jumpArrow.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            jumpArrow.SetActive(false);
        }
    }*/

}
