using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    public float startBoundary;
    public float lastBoundary;

    private void FixedUpdate()
    {
        if (player != null)
        {
            float x = Mathf.Clamp(player.position.x, startBoundary, lastBoundary);
            transform.position = new Vector3(x, 0, -10);
        }
    }
}
