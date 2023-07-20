using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingRaycast : MonoBehaviour
{
    [SerializeField]
    private TestingLine tLine;
    [SerializeField]
    private Transform owner;

    private void Update()
    {
        Vector2 target = Vector2.zero;
        target.x = Input.mousePosition.x - Screen.width * 0.5f;
        target.y = Input.mousePosition.y - Screen.height * 0.5f;

        Vector2 direction = (target - (Vector2)owner.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(owner.position, direction, Mathf.Infinity);

        if (hit)
        {
            tLine.Play(owner.position, hit.point);
        }
        else
        {
            tLine.Stop();
        }
    }
}
