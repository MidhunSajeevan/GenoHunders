
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DoorOpenScript : MonoBehaviour
{
    private Animator m_Animator;
    private powerPlantCollision powerPlant;

    private void Update()
    {
        powerPlant = GameObject.Find("PowerPlant").GetComponent<powerPlantCollision>();
    }
    private void OnTriggerEnter(Collider other)
    {

        m_Animator = GetComponent<Animator>();
        if(powerPlant.isPowerOn)
            m_Animator.SetBool("character_nearby", true);
    }
    private void OnTriggerExit(Collider other)
    {
        m_Animator.SetBool("character_nearby", false);
    }
}
