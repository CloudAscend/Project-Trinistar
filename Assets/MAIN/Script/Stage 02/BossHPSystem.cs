using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPSystem : MonoBehaviour
{
    public Slider bossBar;

    private HPSystem hpSystem;
    private void Awake()
    {
        hpSystem = GetComponent<HPSystem>();
    }

    private void FixedUpdate()
    {
        bossBar.value = hpSystem.hp / (float)hpSystem.maxHp;
    }
}
