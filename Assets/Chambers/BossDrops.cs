using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrops : MonoBehaviour
{
    private bool hit;

    private Vector2 currentVector;

    private Rigidbody2D rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!hit)
            StartCoroutine(DropHand());
        else
            HandUp();
    }

    IEnumerator DropHand()
    {
        yield return new WaitForSeconds(2f);
        rigid.bodyType = RigidbodyType2D.Dynamic;
    }

    void HandUp()
    {
        rigid.bodyType = RigidbodyType2D.Kinematic;
        transform.position = Vector2.Lerp(transform.position, currentVector, Time.deltaTime);
        if ((int)transform.position.y >= (int)currentVector.y)
            hit = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            hit = true;
            rigid.bodyType = RigidbodyType2D.Static;
        }
    }
}
