

using Cinemachine;
using System.Collections;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimStateManager : MonoBehaviour
{
   
    public HipWalkState Hip=new HipWalkState();
    public AimingState Aim=new AimingState();
    AimBaseState currentState;
    [HideInInspector]
    public Animator animator;
    public GameObject Scopeoverlay; 
    public Transform aimposition;
    private float time=.9f;
    public GameObject weponcamera;
    public CinemachineVirtualCamera virtualCamera;
    private float fov = 15f;
    [HideInInspector]
    public float Normalfov = 60f;
    [SerializeField]
    LayerMask aimMask =new LayerMask();
  
    public Transform player;
 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
        SwitchState(Hip);
    }

    void Update()
    {
        currentState.UpdateState(this);
        Vector2 screenCenter=new Vector2(Screen.width/2f, Screen.height/2f);
        Ray ray= Camera.main.ScreenPointToRay(screenCenter);

        if(Physics.Raycast(ray,out RaycastHit hit,Mathf.Infinity,aimMask))
        {
            aimposition.position = hit.point;
          
        }
      
    }
    public void SwitchState(AimBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);

    }
    public IEnumerator onScoped()
    {
        yield return new WaitForSeconds(time);
        Scopeoverlay.SetActive(true);
        weponcamera.SetActive(false);
        virtualCamera.m_Lens.FieldOfView = fov;
      
     
    }
}
