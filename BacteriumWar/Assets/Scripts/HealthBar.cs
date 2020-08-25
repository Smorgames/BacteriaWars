using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHP(int maxHP)
    {
        slider.maxValue = maxHP;
        slider.value = maxHP;
    }

    public void ChangeCurrentHP(int currentHP)
    {
        slider.value = currentHP;
    }
}
