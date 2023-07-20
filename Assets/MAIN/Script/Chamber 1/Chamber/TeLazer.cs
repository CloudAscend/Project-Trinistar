using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeLazer : MonoBehaviour
{
    public float shotTime;
    public float spearSpeed;

    public Transform pointer;
    public Transform spawner;
    public Transform standing;
    public GameObject bullet;

    public Transform lazer;
    private bool lost = false;

    private float timeRate;
    public bool shot = true;

    private Rigidbody2D rigid;
    private BoxCollider2D box;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (rigid.bodyType == RigidbodyType2D.Kinematic)
        {
            float rad = Mathf.Atan2(transform.position.y - pointer.position.y,
                                    transform.position.x - pointer.position.x);
            float deg = rad * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, deg + 180);

            if (Input.GetButtonDown("Fire1") && timeRate < Time.time)
            {
                timeRate = shotTime + Time.time;
                lost = true;
            }

            if (!lost)
            {
                lazer.position = new Vector3(lazer.position.x, 0.33f, 0);
                lazer.localScale = new Vector3(lazer.localScale.x, 0.33f, 0);
                transform.rotation = Quaternion.Euler(0, 0, deg + 180);
            }
            else
            {
                LazerShot();
            }
        }
    }

    private void LazerShot()
    {
        Debug.Log("I Hate People");
        lazer.position += new Vector3(0, -0.1f, 0);
        lazer.localScale += new Vector3(0, 0.2f, 0);

        if (lazer.localScale.y >= 18)
        {
            lost = false;
        }
    }
}
