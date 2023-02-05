using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour, IAudible
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

    public Animator anim;

    public bool isJumping;

    public AudioSource jumpAudioSource;
    public AudioSource landAudioSource;

    [Header("JumpingUI")]
    public GameObject jumpArrow;
    public SpriteRenderer jumpArrowUI;
    GameObject player;
    public Vector3 playerOffset;

    public float rotSpeed;
    void Start()
    {
        jumpIncreaseRate = 0.1f;
        jumpPowerLimit = 25;

        Player = this.gameObject;

        anim = GetComponent<Animator>();
        jumpAudioSource = GameObject.Find("Jump").GetComponent<AudioSource>();
        landAudioSource = GameObject.Find("Land").GetComponent<AudioSource>();
        camera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
        jumpArrowUI = jumpArrow.GetComponentInChildren<SpriteRenderer>();
        jumpArrowUI.enabled = false;
    }


    void Update()
    {

        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            JumpDirection = (hit.point - Player.transform.position).normalized;
            JumpDirection.z = 0;
            Debug.Log(JumpDirection);
        }

        Jump();
        //RotateArrow(JumpDirection);


        if (Player.GetComponent<Rigidbody>().velocity.x > 0)
        {
            anim.SetBool("facingright", true);
        }

        if (Player.GetComponent<Rigidbody>().velocity.x < 0)
        {

            anim.SetBool("facingright", false);
        }
    }

    private void Jump()
    {
        MousePos = Input.mousePosition;

        if (Input.GetMouseButton(0) && !isJumping)
        {
            if (JumpPower <= jumpPowerLimit)
            {
                JumpPower += jumpIncreaseRate;
            }
        }

        if (Input.GetMouseButtonUp(0) && !isJumping)
        {
            //jumpArrowUI.enabled = false;
            isJumping = false;
            Player.GetComponent<Rigidbody>().velocity = JumpPower * JumpDirection;
            JumpPower = 0;
            jumpAudioSource.Play();
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
        anim.SetBool("isjumping", false);
        isJumping = false;

        if(collision.gameObject.tag == "leaf")
        {
            PlaySoundEffect(landAudioSource);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        anim.SetBool("isjumping", true);
        isJumping = true;
    }

    public void PlaySoundEffect(AudioSource soundEffectSource)
    {
        soundEffectSource.Play();
    }
}
