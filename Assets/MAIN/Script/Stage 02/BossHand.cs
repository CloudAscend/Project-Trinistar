using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHand : MonoBehaviour
{
    public GameObject boss;
    public GameObject spike;

    public GameObject fallen;
    public Sprite[] fallenType;

    public Transform player;
    public Transform origin;

    public GameObject damage;

    public GameObject camera;

    private Rigidbody2D rigid;
    private SpriteRenderer sprite;
    private Animator anim;

    private bool move;
    public int action;

    private Transform target;
    private int handScale;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    { 
        if (move) Move();
        if (action == 1) StartCoroutine(Attack1());
        if (action == 2) StartCoroutine(Attack2());
    }

    void Move()
    {
        float lerpX = Mathf.Lerp(transform.position.x, target.position.x, Time.deltaTime * 2f);
        float lerpY = Mathf.Lerp(transform.position.y, handScale, Time.deltaTime);
        transform.position = new Vector3(lerpX, lerpY, 1);
        if (Mathf.Round(transform.localScale.x) == handScale)
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(handScale, handScale), Time.deltaTime);
        else
            transform.localScale = new Vector2(handScale, handScale);
    }

    IEnumerator Attack1()
    {
        //anim.enabled = false;
        action = 3;
        yield return new WaitForSeconds(1f);

        handScale = 4;
        move = true;
        target = player;
        sprite.sortingOrder = 0;
        //anim.SetBool("Stop", true);
        yield return new WaitForSeconds(4.5f);

        move = false;
        anim.SetBool("Stop", true);
        for (int i = 0; i < 3; i++)
        {
            sprite.color = new Color(1, 144 / 255f, 144 / 255f, 1);
            yield return new WaitForSeconds(0.1f);
            sprite.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.1f);
        }
        rigid.bodyType = RigidbodyType2D.Dynamic;
        damage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        damage.SetActive(false);
        yield return new WaitForSeconds(2f);


        rigid.bodyType = RigidbodyType2D.Kinematic;

        move = true;
        target = origin;
        handScale = 2;
        sprite.sortingOrder = -1;

        yield return new WaitForSeconds(2.5f);
        anim.SetBool("Stop", false);
        action = 0;
        boss.GetComponent<BossHead>().active = true;
    }

    IEnumerator Attack2()
    {
        action = 4;
        yield return new WaitForSeconds(1f);

        handScale = 4;
        move = true;
        target = origin;
        anim.SetBool("Stop", true);
        yield return new WaitForSeconds(0.5f);

        move = false;
        rigid.bodyType = RigidbodyType2D.Dynamic;

        yield return new WaitForSeconds(2.5f);

        move = true;
        handScale = 2;
        rigid.bodyType = RigidbodyType2D.Kinematic;
        yield return new WaitForSeconds(1f);
        action = 0;
        anim.SetBool("Stop", false);
        boss.GetComponent<BossHead>().active = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && !move)
        {
            camera.GetComponent<CameraShake>().ShakeCamTime(0.4f);
            if (action == 3)
            {
                rigid.bodyType = RigidbodyType2D.Static;
                Instantiate(spike, new Vector2(transform.position.x, -2f), Quaternion.Euler(0, 0, -90));
                Instantiate(spike, new Vector2(transform.position.x, -2f), Quaternion.Euler(0, 0, 90));
            }

            if (action == 4)
            {
                rigid.bodyType = RigidbodyType2D.Static;
                for (int i = 0; i < 5; i++)
                {
                    fallen.GetComponent<SpriteRenderer>().sprite = fallenType[Random.Range(0, fallenType.Length)];
                    Instantiate(fallen, new Vector2(Random.Range(-11.5f, 11.5f), Random.Range(10, 15)), Quaternion.Euler(0, 0, 180));
                }
            }
        }
    }
}
