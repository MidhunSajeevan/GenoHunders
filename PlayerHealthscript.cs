using UnityEngine;
using UnityEngine.UI;
public class Healthscript : MonoBehaviour
{
    [SerializeField] Slider slider;
    public Gradient gradient;
    public Image Image;
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        gradient.Evaluate(1f);
    }
    
    public void SetHealth(int health)
    {
        
        slider.value= health;
        Image.color = gradient.Evaluate(slider.normalizedValue);
    }

}
