using UnityEngine;

public class BillBoardScript : MonoBehaviour
{

    Transform target;

    // Update is called once per frame
    private void LateUpdate()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        transform.LookAt(transform.position + target.forward); 
    }
}
