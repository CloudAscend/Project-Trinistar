using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingSpearThrow : MonoBehaviour
{
    public float throwSpeed;

    public Transform pointer;
    public Transform standing;
    public Transform Ink;

    // TEST
    private LineRenderer line;

    private Vector3 startPos;
    private Vector3 endPos;

    private int state;

    private Rigidbody2D rigid;
    private void Awake()
    {
        state = 0;
        rigid = GetComponent<Rigidbody2D>();
        line = GetComponent<LineRenderer>();
    }
    private void Update() //FixedUpdate
    {
        if (state == 0) Idle();
        else if (state == 1) Fire();
        else if (state == 2) Back();
        else if (state == 3) line.SetPosition(1, Ink.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6 && (state == 1 || state == 3))
        {
            rigid.bodyType = RigidbodyType2D.Static;
            StartCoroutine(Backgo());
        }

        if (other.gameObject.tag == "Standing" && state == 2)
        {
            state = 0;
        }
    }

    void Idle()
    {
        line.SetPosition(0, Ink.position); //임시 조치
        line.SetPosition(1, Ink.position); //임시 조치

        rigid.bodyType = RigidbodyType2D.Kinematic;

        float rad = Mathf.Atan2(transform.position.y - pointer.position.y,
                                transform.position.x - pointer.position.x);
        float deg = rad * Mathf.Rad2Deg;

        transform.position = standing.position;
        transform.rotation = Quaternion.Euler(0, 0, deg + 180); //FixedUpdate 필요

        if (Input.GetButtonDown("Fire2") && state == 0) //Update 필요
        {
            state = 3;
            line.SetWidth(.3f, .3f);
            line.SetPosition(0, Ink.position);
            StartCoroutine(Delay());
        }
    }

    void Fire()
    {
        rigid.bodyType = RigidbodyType2D.Dynamic;
        transform.right = rigid.velocity;
    }

    void Back()
    {
        rigid.bodyType = RigidbodyType2D.Kinematic;

        float rad = Mathf.Atan2(transform.position.y - standing.position.y,
                                transform.position.x - standing.position.x);
        float deg = rad * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, deg + 180);
        transform.position = Vector2.Lerp(transform.position, standing.position, Time.deltaTime * 2);
    }

    IEnumerator Delay()
    {
        rigid.velocity = transform.right * throwSpeed;

        yield return new WaitForSeconds(1f);

        if (state == 3)
            state = 1;
    }

    IEnumerator Backgo()
    {
        state = 4;

        yield return new WaitForSeconds(5f);

        state = 2;
    }
}
