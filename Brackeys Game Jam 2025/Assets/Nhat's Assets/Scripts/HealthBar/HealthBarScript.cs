using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class HealthBarScript : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }


}
