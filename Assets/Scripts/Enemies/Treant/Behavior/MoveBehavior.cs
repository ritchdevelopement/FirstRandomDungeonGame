using UnityEngine;

public class MoveBehavior : StateMachineBehaviour
{
    private EnemyController enemyController;
    private RoomController roomController;
    private Transform playerPos;

    private Vector2 randMoveDir;

    private float speed;

    // Start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        roomController = animator.gameObject.GetComponentInParent<RoomController>();
        enemyController = animator.gameObject.GetComponent<EnemyController>();
        speed = Random.Range(enemyController.minSpeed, enemyController.maxSpeed);
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        randMoveDir = new Vector2(roomController.transform.position.x + Random.Range(-5.5f, 5.5f), roomController.transform.position.y + Random.Range(-5.5f, 5.5f));
    }

    // Update
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        if(enemyController.following) {
            Follow(animator);
        } else if(enemyController.patrol) {
            Patrol(animator);
        }

        Vector2 heading = playerPos.position - animator.transform.position;
        animator.SetFloat("Horizontal", heading.normalized.x);
        animator.SetFloat("Vertical", heading.normalized.y);
    }

    // Stop
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
    }
    
    private void Patrol(Animator animator) {
        float targetDistance = Vector2.Distance(animator.transform.position, randMoveDir);
        if(targetDistance > 0) {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, randMoveDir, speed * Time.deltaTime);
        } else {
            randMoveDir = new Vector2(roomController.transform.position.x + Random.Range(-5.5f, 5.5f), roomController.transform.position.y + Random.Range(-5.5f, 5.5f));
        }
    }

    private void Follow(Animator animator) {
        float playerDistance = Vector2.Distance(animator.transform.position, playerPos.position);

        if(playerDistance > enemyController.stopDistance) {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);
        } else if(playerDistance <= enemyController.stopDistance) {
            animator.SetBool("Following", false);
        }
    }
}
