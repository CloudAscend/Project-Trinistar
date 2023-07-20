using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBullet : MonoBehaviour
{
    public float shotTime;

    public Transform spawner;
    public GameObject bullet;

    private float timeRate;

    private Rigidbody2D rigid;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rigid.bodyType == RigidbodyType2D.Kinematic)
        {
            if (Input.GetButtonDown("Fire1") && timeRate < Time.time)
            {

                timeRate = shotTime + Time.time;
                Instantiate(bullet, spawner.position, spawner.rotation);
            }
        }
    }
}
