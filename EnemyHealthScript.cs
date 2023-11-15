using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthScript : MonoBehaviour
{
    [SerializeField] Slider slider;
    public Gradient gradient;
    public Image Image;
    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        Image.color = gradient.Evaluate(slider.normalizedValue);
    }
}
