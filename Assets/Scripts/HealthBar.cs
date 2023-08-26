using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider damageSlider;
    public Slider healingSlider;

    public void SetMaxHealth(int health, int maxHealth)
    {
        damageSlider.maxValue = maxHealth;
        damageSlider.value = health;
        healingSlider.maxValue = maxHealth;
        healingSlider.value = maxHealth - health;
    }
    public void SetHealth(int health, int maxHealth)
    {
        damageSlider.value = health;
        healingSlider.value = maxHealth - health;
    }
}
