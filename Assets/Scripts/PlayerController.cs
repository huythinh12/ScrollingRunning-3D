using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle, dirtParticle;
    public AudioClip jumpSound, crashSound;
    AudioSource playerAudio;
    public float jumpForce = 10;
    public float gravityModifier = 2;
    //bool isOnGround = true;
    public bool gameOver = false;
    public bool isDash = false;
    int countJump = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        //begin the game move in 
        if (transform.position.x < -0.3f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 5);
        }
        else
        {
            if (!gameOver)
            {
                Jump();
                DashSkill();
            }
           


        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && countJump < 2)
        {
            countJump++;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }


    }

    private void DashSkill()
    {
        if (Input.GetKey(KeyCode.F))
        {
            playerAnim.SetFloat("valueSpeed", 2);
            isDash = true;
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            playerAnim.SetFloat("valueSpeed", 1);

            isDash = false;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            dirtParticle.Play();
            countJump = 0;

        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            explosionParticle.Play();
            Debug.Log("GameOver");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);

        }
    }
}
