//using UnityEngine;

//public class WalkingState : MovementBaseState
//{
//    public override void EnterState(PlayerMovement movement)
//    {
//        movement.animator.SetBool("walking", true);
//    }

//    public override void UpdateState(PlayerMovement movement)
//    {
//       if(Input.GetKeyDown(KeyCode.LeftShift))
//        {
//            ExitState(movement, movement.running);
//        }else if(movement.move.magnitude < 0f)
//        {
//            ExitState(movement, movement.idl);
//        }
//    }
//    void ExitState(PlayerMovement movement,MovementBaseState state)
//    {
//        movement.animator.SetBool("walking", false);
//        movement.SwitchState(state);
//    }
//}
