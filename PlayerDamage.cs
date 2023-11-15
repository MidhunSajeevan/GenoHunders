using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    GameObject player;
    private PlayerMovement PlayerMovement;
    void Start()
    {
        player = GameObject.Find("Player");
        PlayerMovement =player.GetComponent<PlayerMovement>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerMovement.TakeDamage(10);
        }
    }
}
