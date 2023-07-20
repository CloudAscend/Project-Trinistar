using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeMonster : MonoBehaviour
{
    public int nextMove;
    public float speed;
    public float fireTime;

    public Transform target;
    public Transform spawner;
    public Transform[] boundary;
    public GameObject bullet;

    public LayerMask groundCheck;

    private float timeRate;

    private BoxCollider2D box;
    private Rigidbody2D rigid;
    private SpriteRenderer sprite;
    private TeHPSystem hpStem;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
        hpStem = GetComponent<TeHPSystem>();
    }

    private void FixedUpdate()
    {
        if (nextMove != 0 && nextMove != 2 && nextMove != -2)
            Walk();
        else
            Attake();
    }

    private void Walk()
    {
        rigid.velocity = new Vector2(nextMove * speed, rigid.velocity.y);
        sprite.flipX = nextMove < 0 == true;

        if (transform.position.x <= boundary[0].position.x)
            nextMove = 1;

        if (transform.position.x >= boundary[1].position.x)
            nextMove = -1;
    }

    private void Attake()
    {
        if (target != null)
        {
            float rad = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x);
            float deg = rad * Mathf.Rad2Deg;

            if (timeRate < Time.time)
            {
                timeRate = fireTime + Time.time;
                Instantiate(bullet, spawner.position, Quaternion.Euler(0, 0, deg + 90));
            }
            sprite.flipX = target.position.x < transform.position.x == true;

            if (nextMove == 2 || nextMove == -2)
            {
                box.isTrigger = false;
                rigid.velocity = new Vector2(nextMove * speed, rigid.velocity.y);
                if (sprite.flipX)
                    nextMove = -2;
                else
                    nextMove = 2;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player") && isGrounded())
        {
            nextMove = 0;
            rigid.bodyType = RigidbodyType2D.Static;
            box.isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (sprite.flipX)
                nextMove = -2;
            else
                nextMove = 2;
            rigid.bodyType = RigidbodyType2D.Dynamic;
            box.isTrigger = false;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, .1f, groundCheck);
    }
}
