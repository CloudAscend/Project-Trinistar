using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    public Slider hpBar;
    public Slider mpBar;

    public GameObject spear;

    private HPSystem hpSystem;
    private void Awake()
    {
        hpSystem = GetComponent<HPSystem>();
    }

    private void FixedUpdate()
    {
        hpBar.value = hpSystem.hp / 20f;
        mpBar.value = spear.GetComponent<MPSystem>().mp / 100f;
    }
}
