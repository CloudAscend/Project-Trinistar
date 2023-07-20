using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCoroutine : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(tryCoroutine());
    }

    IEnumerator tryCoroutine()
    {
        Debug.Log($"Coroutine ����!!{Time.time}");
        yield return new WaitForSeconds(1.0f); //1�� ������
        Debug.Log($"Coroutine ����!!{Time.time}");
    }
}
