using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeSpearThrow : MonoBehaviour
{
    public float spearSpeed;
    public float rotSpeed;
    public float retrieveSpeed;

    //public Transform pointer;
    public Transform player;
    public Transform standing;

    private bool fire = false;

    private Rigidbody2D rigid;
    private BoxCollider2D box;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (rigid.bodyType != RigidbodyType2D.Static && player != null)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                rigid.velocity = transform.right * spearSpeed;
                fire = true;
            }

            if (!fire)
            {
                transform.position = standing.position;
                box.isTrigger = true;
                rigid.bodyType = RigidbodyType2D.Kinematic;

            }
            else
            {
                rigid.bodyType = RigidbodyType2D.Dynamic;
                transform.right = rigid.velocity;
                box.isTrigger = false;
            }
        }
    }

    void Destart()
    {
        rigid.bodyType = RigidbodyType2D.Kinematic;
        fire = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6 && rigid.bodyType == RigidbodyType2D.Dynamic)
        {
            box.isTrigger = true;
            Invoke("Destart", 5);
            rigid.bodyType = RigidbodyType2D.Static;
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            rigid.bodyType = RigidbodyType2D.Kinematic;
            box.isTrigger = false;
            fire = false;
        }
    }
    */
}
