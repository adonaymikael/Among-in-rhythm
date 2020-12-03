using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject playerComponents;
    public Animator playerAnimation;
    public SpriteRenderer playerSprite;
    public Sprite amongSit;
    public Rigidbody2D playerRigid;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public static float sitTimer;
    public float idleTimer;
    public float moveSpeed = 5;
    public float jumpForce = 0.1f;
    public float groundCheckRadius = 0.2f;
    public bool grounded;


    // Start is called before the first frame update
    void Start()
    {
        playerComponents = GameObject.FindGameObjectsWithTag("Player")[0];
        playerAnimation = playerComponents.GetComponent<Animator>();
        playerSprite = playerComponents.GetComponent<SpriteRenderer>();
        playerRigid = playerComponents.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        playerRigid.velocity = new Vector2(h*moveSpeed, playerRigid.velocity.y);

        AnimatorStateInfo animationState = playerAnimation.GetCurrentAnimatorStateInfo(0);
        AnimatorClipInfo[] myAnimatorClip = playerAnimation.GetCurrentAnimatorClipInfo(0);
        float speedPlayer = playerAnimation.GetFloat("speed");
        bool groundedPlayer = playerAnimation.GetBool("grounded");
        idleTimer = myAnimatorClip[0].clip.length * animationState.normalizedTime;
        playerAnimation.SetFloat("timer",idleTimer);
        playerAnimation.SetFloat("speed", Mathf.Abs(h));
        float timerPlayer = playerAnimation.GetFloat("timer");

        if(h > 0){
            Flip(false);
        }else if(h < 0){
            Flip(true);
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if(grounded && Input.GetButtonDown("Jump")){
            playerRigid.AddForce(Vector2.up * jumpForce);
        }

        playerAnimation.SetBool("grounded", grounded);
        
        //Debug.Log(timerPlayer);

        if (playerSprite.sprite == amongSit && speedPlayer <= 0 && groundedPlayer)
        {
                sitTimer = myAnimatorClip[0].clip.length * animationState.normalizedTime;
                playerAnimation.PlayInFixedTime("Player_sit", -1, sitTimer);
                //Debug.Log(sitTimer);
        }

        //Debug.Log("Timer: "+idleTimer);
    }

    void Flip(bool f){
       playerSprite.flipX = f;
    }
}
