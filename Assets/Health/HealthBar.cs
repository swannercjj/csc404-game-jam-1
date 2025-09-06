using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
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
