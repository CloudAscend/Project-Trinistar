using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateThing : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.unscaledDeltaTime);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
