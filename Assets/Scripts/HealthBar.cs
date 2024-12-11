using UnityEngine;
using UnityEngine.UI;

//Manages a health bar UI element.
public class HealthBar : MonoBehaviour
{
    public Slider slider; //Reference to the Slider UI component

    //Sets the maximum health value for the health bar.
    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    //Updates the health bar's value.

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
