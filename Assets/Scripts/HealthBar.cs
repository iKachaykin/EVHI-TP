using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider sliderOfHealthBar;
    public Health healthOfPlayer;

    // Start is called before the first frame update
    void Start()
    {
        healthOfPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        sliderOfHealthBar = GetComponent<Slider>();
        sliderOfHealthBar.maxValue = healthOfPlayer.maxHealth;
        sliderOfHealthBar.value = healthOfPlayer.maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth(int health)
    {
        sliderOfHealthBar.value = health;
    }
}
