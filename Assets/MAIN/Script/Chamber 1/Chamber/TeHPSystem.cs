using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeHPSystem : MonoBehaviour
{
    public GameObject Thing;

    public GameObject[] damageThings;
    public int[] damageCounts;

    public int maxHp;

    public int hp;

    private float rateTime;
    private void Awake()
    {
        hp = maxHp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < damageThings.Length; i++)
        {
            if (collision.gameObject.tag == damageThings[i].tag)
            {
                Destroy(collision.gameObject);
                StartCoroutine(Damage(damageCounts[i]));
            }
        }
    }

    IEnumerator Damage(int d)
    {
        hp -= d;
        Mathf.Clamp(hp, 0, maxHp);

        //if (hp <= 0)
        //    Destroy(Thing);

        Thing.GetComponent<SpriteRenderer>().color = new Color(1, 144 / 255f, 144 / 255f, 1);
        yield return new WaitForSeconds(0.2f);
        Thing.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
