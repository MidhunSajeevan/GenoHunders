using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class WeponUi : MonoBehaviour
{

    public Image[] images;
    private WeponSwitching weponSwitching;
    private WeponManager weponManager;
    private AutoGunScripts autoGunScripts;
    [SerializeField] private TMP_Text Snipertext;
    [SerializeField] private TMP_Text SniperMag;
    [SerializeField] private TMP_Text AutoGuntext;
    [SerializeField] private TMP_Text AutoMag;
    [SerializeField] GameObject Sniper;
    [SerializeField] GameObject AutoGun;

    private void Start()
    {
        images = GetComponentsInChildren<Image>();   
        weponSwitching = GameObject.Find("WeponHolder").GetComponent<WeponSwitching>();
        weponManager = Sniper.GetComponent<WeponManager>();
        autoGunScripts = AutoGun.GetComponent<AutoGunScripts>();
      


    }

    private void Update()
    {

      SniperMag.text = WeponManager.Maxmag.ToString();
      Snipertext.text= WeponManager.GunAmo.ToString();
        AutoMag.text = AutoGunScripts.Maxmagauto.ToString();
        AutoGuntext.text = AutoGunScripts.GunAmo.ToString() ;   
     

        if (weponSwitching.selectedWepon == 0)
        {
      
            images[2].color = Color.white;
            images[1].color = new Color32(255, 255, 225, 100);
            
        }
        else
        {
;
            images[1].color = Color.white;
            images[2].color = new Color32(255, 255, 225, 100);
           
        }
      
    }
}
