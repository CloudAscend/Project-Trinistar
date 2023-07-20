using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;

    //public GameObject standing;

    public float move = 0;

    [SerializeField] private LayerMask jumpableGround;

    private Rigidbody2D rigid;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    private enum MovementState { idle, run }
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        move = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rigid.velocity = new Vector2(0, jumpPower);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        rigid.velocity = new Vector2(move * moveSpeed, rigid.velocity.y);

        UpdateAnim();
    }

    private void UpdateAnim()
    {
        MovementState state;

        if (move != 0f)
        {
            state = MovementState.run;
            sprite.flipX = move < 0 == true;
        }
        else
        {
            state = MovementState.idle;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        //BoxCast에서 바닥에 체크될 때 true를 반환
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
