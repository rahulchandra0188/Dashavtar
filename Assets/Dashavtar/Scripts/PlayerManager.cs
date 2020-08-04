using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerManager : MonoBehaviour
{
    #region variables

    public float runSpeed;
    public float jumpForce;

    private Rigidbody2D rb;
    private float moveInputHorz;

    private bool isFacingRight = true;

    private bool isGrounded;
    public Transform feetpos;
    public float localradius;
    public LayerMask whatisGround;
    private bool canJump;
    private bool canDoublejump = false;

    public GameObject idle_Parshuram;
    public GameObject run_Parshuram;

    

    //public Joystick joystick;

    #endregion

    #region Functions

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        
        //to flip character based on input controls
        CheckMovementDirection();

        //parshuram level
        ParshuramLevel();

        isGrounded = Physics2D.OverlapCircle(feetpos.position, localradius, whatisGround);
        if (isGrounded == true)
        {
            canDoublejump = true;
        }
            
        

    }

    private void FixedUpdate()
    {
        moveInputHorz = CrossPlatformInputManager.GetAxis("Horizontal") * runSpeed * Time.fixedDeltaTime;

        rb.velocity = new Vector2(moveInputHorz, rb.velocity.y);

         
    }

    void CheckMovementDirection()
    {
        if(isFacingRight && moveInputHorz < 0)
        {
            Flip();
        }

        else if(!isFacingRight && moveInputHorz > 0)
        {
            Flip();
        }
            
    }
    
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180f, 0);
    }

    public void Jump()
    {
        
        if(isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime);

        }
        else if(canDoublejump)
        {
            Debug.Log("yes");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime);
            canDoublejump = false;
        }

    }

    

    void ParshuramLevel()
    {
        if (moveInputHorz == 0)
        {
            idle_Parshuram.SetActive(true);
            run_Parshuram.SetActive(false);
        }

        if(moveInputHorz > 0 || moveInputHorz < 0)
        {
            idle_Parshuram.SetActive(false);
            run_Parshuram.SetActive(true);
        }

    }
    #endregion 
}
