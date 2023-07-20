using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : MonoBehaviour
{
    [Header ("필살기")]
    public int state;
    public float throwSpeed;
    public float penSize;

    public GameObject line;
    public GameObject Ink;

    public Transform pointer;
    public Transform standing;

    [Header("공격")]
    public float shotTime;

    public Transform spawner;
    public GameObject bullet;

    private float timeRate;

    private Rigidbody2D rigid;
    private MPSystem mpSystem;
    private void Awake()
    {
        state = 0;
        rigid = GetComponent<Rigidbody2D>();
        mpSystem = GetComponent<MPSystem>();
    }
    private void FixedUpdate()
    {
        if (state == 0) Idle();
        if (state == 1 && mpSystem.mp > 0) line.GetComponent<LineRenderer>().SetPosition(1, Ink.transform.position);
        if (state == 2) Spin();
        if (state == 4) Back();
    }

    private void Update()
    {
        if (state == 0)
        {
            if (Input.GetButtonDown("Fire1") && timeRate < Time.time)
            {
                timeRate = shotTime + Time.time;
                Instantiate(bullet, spawner.position, spawner.rotation);
            }

            if (Input.GetButtonDown("Fire2") && mpSystem.mp > 0)
            {
                rigid.bodyType = RigidbodyType2D.Kinematic;

                state = 1;
                Ink.SetActive(true);
                line.GetComponent<LineRenderer>().SetWidth(penSize, penSize);
                line.GetComponent<LineRenderer>().SetPosition(0, Ink.transform.position);
                StartCoroutine(Fire());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6 && (state == 1 || state == 2))
        {
            rigid.bodyType = RigidbodyType2D.Static;
            StartCoroutine(Backgo());
        }

        if (other.gameObject.tag == "Standing" && state == 4)
        {
            state = 0;
        }
    }

    void Idle()
    {
        Ink.SetActive(false);
        line.GetComponent<LineRenderer>().SetPosition(0, Ink.transform.position);
        line.GetComponent<LineRenderer>().SetPosition(1, Ink.transform.position);
        line.GetComponent<LineRenderer>().enabled = true;

        float rad = Mathf.Atan2(transform.position.y - pointer.position.y,
                                transform.position.x - pointer.position.x);
        float deg = rad * Mathf.Rad2Deg;

        transform.position = standing.position;
        transform.rotation = Quaternion.Euler(0, 0, deg + 180);
    }

    void Spin()
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

    IEnumerator Fire()
    {
        rigid.velocity = transform.right * throwSpeed;

        yield return new WaitForSeconds(1.2f);

        if (state == 1)
            state = 2;
    }

    IEnumerator Backgo()
    {
        state = 3;

        yield return new WaitForSeconds(5f);

        state = 4;
        line.GetComponent<LineRenderer>().enabled = false;
    }
}
