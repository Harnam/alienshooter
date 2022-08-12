using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    public bool isAlive = true;

    private Rigidbody2D rigid;

    private string GROUND_TAG = "ground";
    private string ENEMY_TAG = "Enemy";

    private bool isGrounded = true;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isAlive)
        {
            PlayerMove();
            //AnimatePlayer();
            PlayerJump();
        }
    }

    void PlayerMove()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rigid.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            playerDie();
        }
    }

    void playerDie()
    {
        isAlive = false;
    }
}
