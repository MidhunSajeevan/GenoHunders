using System.Collections;
using UnityEngine;


public class gunAmo : MonoBehaviour
{

    [SerializeField] GameObject Pannel;
    bool pick=false;
       
        
    
    
    private void OnTriggerEnter(Collider other)
    {
     
        if (other.CompareTag("Player") && this.CompareTag("SniperAmo"))
        {
                 
            Pannel.SetActive(true);
            Pannel.transform.GetChild(0).gameObject.SetActive(true);
             PickupAmmo(7);
        }
      if (other.CompareTag("Player") && this.CompareTag("AutoGunAmo"))
        {
            Pannel.SetActive(true);
            Pannel.transform.GetChild(1).gameObject.SetActive(true);
            PickupAutoAmmo(40);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        Pannel.transform.GetChild(0).gameObject.SetActive(false);
        Pannel.transform.GetChild(1).gameObject.SetActive(false);
        Pannel.SetActive(false);
    }
    void PickupAmmo(int amo)
    {
   
        StartCoroutine(DelayFuction());
        if (pick)
        {
            WeponManager.Maxmag += amo;
            Destroy(this.gameObject);
            Pannel.SetActive(false);
            Pannel.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    void PickupAutoAmmo(int amo)
    {
      
        StartCoroutine(DelayFuction());
        if (pick)
        {
            AutoGunScripts.Maxmagauto += amo;
            Destroy(this.gameObject);
            Pannel.SetActive(false);
            Pannel.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    IEnumerator DelayFuction()
    {
        yield return new WaitForSeconds(1);
        pick = true;
    }
}
