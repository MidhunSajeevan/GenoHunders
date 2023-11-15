using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    float MouseSensitivity = 100f;
    [SerializeField] 
    Transform playerBody;
    float XRotaion = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX=Input.GetAxis("Mouse X")*MouseSensitivity*Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        XRotaion -= MouseY;
        XRotaion= Mathf.Clamp(XRotaion, -60f, 50f);
        transform.localRotation=Quaternion.Euler(XRotaion,0f,0f);
        playerBody.Rotate(Vector3.up * MouseX);
      
    }
}
