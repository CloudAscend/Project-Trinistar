using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TePenDraw : MonoBehaviour
{
    public float shotTime;
    public float spearSpeed;

    public Transform pointer;
    public Transform spawner;
    public Transform standing;
    public GameObject bullet;

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
                shot = false;
                timeRate = shotTime + Time.time;
                Instantiate(bullet, spawner.position, spawner.rotation);
            }
        }
    }
}
