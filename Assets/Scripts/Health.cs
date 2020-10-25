using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int currentHealth = 0;
    public int maxHealth = 100;
    public bool healthBarEnabled = true;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void GetDamage(int damage)
    {
        currentHealth -= damage >= 0 ? damage : 0;
        currentHealth = currentHealth < 0 ? 0 : currentHealth;
        if (healthBarEnabled)
            healthBar.SetHealth(currentHealth);
    }

    public void GetHealing(int healing)
    {
        currentHealth += healing >= 0 ? healing : 0;
        currentHealth = currentHealth > maxHealth ? maxHealth : currentHealth;
        if (healthBarEnabled)
            healthBar.SetHealth(currentHealth);
    }
}
