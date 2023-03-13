using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///脚本：PlayerControl.cs
///时间：2022/9/3 15:20
///功能：角色控制脚本
///</summary>
public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float jumpSpeed1;
    public float jumpSpeed2;

    public GameWindow gamewindow;

    private int jumpCount = 2;
    private Vector3 playerScale;
    private Rigidbody2D playerRigidBody;
    private Animator playerAni;
    private CapsuleCollider2D playerFeet;

    public void InitPlayer()
    {
        playerScale = transform.localScale;
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAni = GetComponent<Animator>();
        playerFeet = GetComponent<CapsuleCollider2D>();
    }
    
    void Update()
    {
        Run();
        Jump();
        Fall();
        IfOnLand();
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = playerScale;
            playerRigidBody.velocity = new Vector2(speed, playerRigidBody.velocity.y);
            playerAni.SetBool("ifRun",true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-playerScale.x, playerScale.y, playerScale.z);
            playerRigidBody.velocity = new Vector2(-speed, playerRigidBody.velocity.y);
            playerAni.SetBool("ifRun",true);
        }
        else
        {
            playerRigidBody.velocity = new Vector2(0, playerRigidBody.velocity.y);
            playerAni.SetBool("ifRun",false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && jumpCount != 0)
        {
            playerAni.SetBool("ifJump",true);
            playerAni.SetBool("ifFall",false);
            playerAni.SetBool("ifIdle",false);
            if (jumpCount == 2)
            {
                playerRigidBody.velocity = Vector2.up * jumpSpeed1;
            }
            else if (jumpCount == 1)
            {
                playerRigidBody.velocity = Vector2.up * jumpSpeed2;
                jumpCount--;
            }
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift) && jumpCount != 0)
        {
            if(playerRigidBody.velocity.y > 3f)
            {
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, 3f);
            }
        }
    }

    private void Fall()
    {
        if (playerRigidBody.velocity.y <= 0f)
        {
            playerAni.SetBool("ifJump",false);
            playerAni.SetBool("ifIdle",false);
            playerAni.SetBool("ifFall",true);
        }
        if (playerRigidBody.velocity.y < -8f)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, -8f);
        }
    }

    private void IfOnLand()
    {
        if (playerFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            jumpCount = 2;
            if(playerAni.GetBool("ifFall") is true)
            {
                playerAni.SetBool("ifFall",false);
                playerAni.SetBool("ifIdle",true);
            }
            
        }else
        {
            if(jumpCount == 2)
            {
                jumpCount--;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Spike"))
        {
            gamewindow.GameOver();
        }
        else if (collision.transform.CompareTag("NextLevelSign"))
        {
            gamewindow.NextLevel();
        }
    }
}
