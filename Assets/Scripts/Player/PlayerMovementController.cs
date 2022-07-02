using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D rb2d;

    public float moveSpeed = 5f;

    private PlayerShootingController playerShootingController;

    private Vector3 aimDirNormalized;
    private Vector2 movement;

    private void Start() {
        playerShootingController = GetComponent<PlayerShootingController>();
    }

    // Update is called once per frame
    void Update()
    {
        aimDirNormalized = playerShootingController.aimDir.normalized;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Horizontal", aimDirNormalized.x);
        animator.SetFloat("Vertical", aimDirNormalized.y);
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
