using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody;
    public float MoveForce=100;
    public float JumpForce = 100;
    private float fInput = 0.0f;
    public float MaxSpeed = 5;
    private bool bFaceRight = true;
    private bool bGrounded = false;
    Transform mGroundCheck;
    private bool bJump;

    void Start()
    {
      rigidBody = GetComponent<Rigidbody2D>();
        mGroundCheck = transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        float fInput = Input.GetAxis("Horizontal");
        if (fInput > 0 && !bFaceRight)
        {
            flip();
        }
        else if (fInput < 0 && bFaceRight)
        {
            flip();
        }
        bJump = false;
        {
            if(bGrounded)
                bJump=Input.GetKeyDown(KeyCode.Space);
            Vector2 upForce = new Vector2(0, 1);
            if(bJump)
            rigidBody.AddForce(upForce * JumpForce);
        }
        
        bGrounded =Physics2D.Linecast(transform.position, mGroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
      mGroundCheck = transform.Find("GroundCheck");

        
    }


    void FixedUpdate()
        {
            float fInput = Input.GetAxis("Horizontal");
            Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
            //控制移动
            if (fInput * rigidBody.velocity.x < MaxSpeed)
            {
                rigidBody.AddForce(Vector2.right * fInput * MoveForce);
            }
            //限制最大速度
            if (Mathf.Abs(rigidBody.velocity.x) > MaxSpeed)
            {
                rigidBody.velocity = new Vector2(Mathf.Sign(rigidBody.velocity.x) * MaxSpeed, rigidBody.velocity.y);
            }



        


        if (bJump)
        {
            
            rigidBody.AddForce(new Vector2(0f, JumpForce));
            bJump = false;
        }


    }

    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;
    }
}
