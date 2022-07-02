using UnityEngine;

public class IdleBehavior : StateMachineBehaviour
{
    private Transform playerPos;

    private float stopDistance;
    private float playerDistance;

    // Start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        stopDistance = animator.gameObject.GetComponent<EnemyController>().stopDistance;
    }

    // Update
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        playerDistance = Vector2.Distance(animator.transform.position, playerPos.position);

        if (playerDistance > stopDistance)
        {
            animator.SetBool("Following", true);
        }

        Vector2 heading = playerPos.position - animator.transform.position;
        animator.SetFloat("Horizontal", heading.normalized.x);
        animator.SetFloat("Vertical", heading.normalized.y);

    }

    // Stop
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
    }

}
