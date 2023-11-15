using UnityEngine;

public class powerPlantCollision : MonoBehaviour
{
 public  bool isPowerOn=false;
  [SerializeField] private GameObject power;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isPowerOn)
            {
                power.SetActive(true);
                isPowerOn = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        power.SetActive(false);
    }
}
