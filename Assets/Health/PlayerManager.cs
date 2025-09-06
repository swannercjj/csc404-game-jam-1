using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public HealthBar healthBar1;
    public HealthBar healthBar2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        healthBar1.setSliderMax(healthBar1.maxHealth);
        healthBar2.setSliderMax(healthBar2.maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
