//using UnityEngine;

//public class RunningState : MovementBaseState
//{
//    public override void EnterState(PlayerMovement movement)
//    {
//        movement.animator.SetBool("running", true);
//    }

//    public override void UpdateState(PlayerMovement movement)
//    {
//        if (Input.GetKeyUp(KeyCode.LeftShift))
//        {
//            ExitState(movement, movement.walk);
//        }
//        else if (movement.move.magnitude < 0f)
//        {
//            ExitState(movement, movement.idl);
//        }
//    }
//    void ExitState(PlayerMovement movement, MovementBaseState state)
//    {
//        movement.animator.SetBool("running", false);
//        movement.SwitchState(state);
//    }
//}
