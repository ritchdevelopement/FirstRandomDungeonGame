using UnityEngine;

public class DeathBehavior : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponentInParent<RoomController>().enemyCap--;
        Destroy(animator.gameObject, stateInfo.length);
    }
}
