
using UnityEngine;

public class HipWalkState : AimBaseState
{
    public override void EnterState(AimStateManager aim)
    {
        aim.animator.SetBool("aiming", false);
        aim.animator.SetBool("hipwalk", true);
    }
    public override void UpdateState(AimStateManager aim)
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            aim.SwitchState(aim.Aim);
            aim.StartCoroutine(aim.onScoped());
           
        }
       
    }
}
