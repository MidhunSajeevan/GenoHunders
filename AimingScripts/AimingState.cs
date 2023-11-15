using UnityEngine;

public class AimingState : AimBaseState
{
    public override void EnterState(AimStateManager aim)
    {
        aim.animator.SetBool("aiming", true);
        aim.animator.SetBool("hipwalk", false);
     
     
    }
    public override void UpdateState(AimStateManager aim)
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            aim.SwitchState(aim.Hip);
            aim.Scopeoverlay.SetActive(false);
            aim.weponcamera.SetActive(true);
            aim.virtualCamera.m_Lens.FieldOfView = aim.Normalfov;
        }
        

    }
}
