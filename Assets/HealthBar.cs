using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject _youDied;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = slider.value - health;
    }

    public void HealHealth(int health)
    {
        slider.value = health;
    }

    private void Update()
    {
        if(slider.value == 0)
        {
            _youDied.SetActive(true);
        }
    }

}
