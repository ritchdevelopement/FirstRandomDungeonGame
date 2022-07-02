using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;

    [Header("General Enemy Settings")]
    public float stopDistance;
    public float minSpeed;
    public float maxSpeed;
    [HideInInspector] public bool dead = false;

    [Header("Enemy Move Behavior")]
    public bool following = true;
    public bool patrol = false;

    private HealthController healthController;
    private EnemyShootingController enemyShootingController;

    // Start is called before the first frame update
    private void Start()
    {
        healthController = GetComponent<HealthController>();
        enemyShootingController = GetComponent<EnemyShootingController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(healthController.currentHealth < 1)
        {
            ExplodeProjectiles();
            transform.DetachChildren();
            dead = true;
            animator.SetBool("Dead", true);
        }
    }

    public void ExplodeProjectiles() {
        if(enemyShootingController.firedProjectiles.Count > 0) {
            foreach(GameObject projectile in enemyShootingController.firedProjectiles) {
                if(projectile != null) {
                    ProjectileContoller projectileContoller = projectile.GetComponent<ProjectileContoller>();
                    Instantiate(projectileContoller.explosion, projectile.transform.position, projectileContoller.explosion.transform.rotation);
                    Destroy(projectile);
                }
            }
        }
    }
}
