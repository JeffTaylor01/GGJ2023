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
    public int jumpCount;
    public int extraJumpLimit;

    public bool canDoubleJump;

    public AudioSource jumpAudioSource;
    public AudioSource landAudioSource;

    [Header("JumpingUI")]
    public GameObject jumpArrow;
    public SpriteRenderer jumpArrowUI;
    GameObject player;
    public Vector3 playerOffset;

    public float rotSpeed;
    public GameObject dust;

    void Start()
    {
        jumpIncreaseRate = 0.1f;

        jumpCount = 0;
        extraJumpLimit = 1;

        Player = this.gameObject;

        anim = GetComponent<Animator>();
        jumpAudioSource = GameObject.Find("Jump").GetComponent<AudioSource>();
        landAudioSource = GameObject.Find("Land").GetComponent<AudioSource>();
        camera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
        jumpArrowUI = jumpArrow.GetComponentInChildren<SpriteRenderer>();
        jumpArrowUI.enabled = false;

        dust = GameObject.Find("CFXR3 Hit Misc F Smoke");
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
        LimitJump();

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

        if (Input.GetMouseButton(0) && canDoubleJump)
        {
            if (JumpPower <= jumpPowerLimit)
            {
                JumpPower += jumpIncreaseRate;
            }
        }

        if (Input.GetMouseButtonUp(0) && canDoubleJump)
        {
            isJumping = true;
            Player.GetComponent<Rigidbody>().velocity = JumpPower * JumpDirection;
            JumpPower = 0;
            jumpAudioSource.Play();

            jumpCount++;

        }


    }
    public void LimitJump()
    {
        if (isJumping == true)
        {
            if (jumpCount > extraJumpLimit)
            {
                canDoubleJump = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        anim.SetBool("isjumping", false);

        if (collision.gameObject.tag == "leaf")
        {
            dust.GetComponent<ParticleSystem>().Play();
            PlaySoundEffect(landAudioSource);
            jumpCount = 0;
            isJumping = false;
            canDoubleJump = true;
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
