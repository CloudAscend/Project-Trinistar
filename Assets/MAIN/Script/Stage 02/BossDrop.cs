using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrop : MonoBehaviour
{
    public GameObject boss;
    public GameObject rain;
    public Transform origin;

    private Rigidbody2D rigid;

    private bool move;
    public bool action;

    private int handScale;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (move)   Move();
        if (action) StartCoroutine(Attack());
    }

    void Move()
    {
        float lerpX = Mathf.Lerp(transform.position.x, origin.position.x, Time.deltaTime * 2f);
        float lerpY = Mathf.Lerp(transform.position.y, 4, Time.deltaTime);
        transform.position = new Vector3(lerpX, lerpY, 1);
        if (Mathf.Round(transform.localScale.x) == handScale)
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(handScale, handScale), Time.deltaTime);
        else
            transform.localScale = new Vector2(handScale, handScale);
    }

    IEnumerator Attack()
    {
        action = false;
        yield return new WaitForSeconds(1f);
        handScale = 4;
        yield return new WaitForSeconds(0.5f);
        move = false;

        for (int i = 0; i < 3; i++)
        {
            rigid.bodyType = RigidbodyType2D.Dynamic;
            yield return new WaitForSeconds(2.5f);
            rigid.bodyType = RigidbodyType2D.Kinematic;
            move = true;
            yield return new WaitForSeconds(2.5f);
        }

        yield return new WaitForSeconds(2.5f);
        handScale = 2;
        boss.GetComponent<BossHead>().active = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            rigid.bodyType = RigidbodyType2D.Static;
            for (int i = 0; i < 5; i++)
                Instantiate(rain, new Vector2(Random.Range(-11.5f, 11.5f), 10), Quaternion.Euler(0, 0, 180));
        }
    }
}
