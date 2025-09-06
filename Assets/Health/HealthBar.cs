using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public bool isAlive = true;

    public Slider healthSlider;
    
    public event Action OnPlayerDeath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void setSlider(float amount)
    {
        healthSlider.value = amount;
    }

    public void setSliderMax(float amount)
    {
        healthSlider.maxValue = amount;
        setSlider(amount);
    }
}
