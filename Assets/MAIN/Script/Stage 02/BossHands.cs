using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHands : MonoBehaviour
{
    public GameObject boss;
    public GameObject spike;
    public Transform target;

    private Rigidbody2D rigid;
    private SpriteRenderer sprite;

    private bool clock;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        StartCoroutine(Attack()); //?
    }

    private void Update()
    {
        if (clock)
            Idle();
    }

    void Idle()
    {
        float follow = Mathf.Lerp(transform.position.x, target.position.x, Time.deltaTime * 2f);
        transform.position = new Vector3(follow, Mathf.Lerp(transform.position.y, 4, Time.deltaTime), 1);
        if (transform.localScale.x < 3.99f)
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(4, 4), Time.deltaTime);
        else
            transform.localScale = new Vector2(4, 4);
        //transform.localScale = transform.localScale.x < 3.99f == new Vector2(4, 4);
    }

    /*
     Idle() , Signal() , Attack()
     */

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1f);
        clock = true;
        yield return new WaitForSeconds(5f);
        //yield return new WaitForSeconds(10f);

        clock = false;
        for (int i = 0; i < 3; i++)
        {
            sprite.color = new Color(0, 241 / 255f, 1f, 1);
            yield return new WaitForSeconds(0.1f);
            sprite.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.1f);
        }
        rigid.bodyType = RigidbodyType2D.Dynamic;

        yield return new WaitForSeconds(3f);

        rigid.bodyType = RigidbodyType2D.Kinematic;

        clock = true;
        gameObject.GetComponent<BossHands>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && !clock)
        {
            rigid.bodyType = RigidbodyType2D.Static;
            Instantiate(spike, new Vector2(transform.position.x, -4f), Quaternion.Euler(0, 0, -90));
            Instantiate(spike, new Vector2(transform.position.x, -4f), Quaternion.Euler(0, 0, 90));
        }
    }
}
