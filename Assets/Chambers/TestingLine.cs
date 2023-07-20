using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingLine : MonoBehaviour
{
    private LineRenderer line;
    private void Awake()
    {
        line = GetComponent<LineRenderer>();

        line.positionCount = 2;
        line.enabled = false;
    }

    public void Play(Vector3 from, Vector3 to)
    {
        line.enabled = true;

        line.SetPosition(0, from);
        line.SetPosition(1, to);
    }

    public void Stop()
    {
        line.enabled = false;
    }
}
