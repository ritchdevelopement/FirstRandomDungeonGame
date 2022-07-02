using UnityEngine;

public class ProjectileContoller : MonoBehaviour
{
    public GameObject explosion = null;

    [Header("General Projectile Settings")]
    public int damage = 0;
    public bool isStickable = false;
    public bool isPickable = false;
    public bool isRotating = false;

    private void Update() {
        if(isRotating) {
            transform.Rotate(Vector3.forward * 20 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if(damagable != null) {
            damagable.TakeDamage(damage);

            if(isStickable == true) {
                Stick(collision);
            } else {
                Explode();
                Destroy(gameObject);
            }
        } else if(damagable == null && !isStickable){
            Explode();
            Destroy(gameObject);
        } else if((damagable == null || damagable != null) && isStickable) {
            Stick(collision);
        }
    }

    private void Stick(Collision2D collision) {
        Destroy(GetComponent<Rigidbody2D>());
        transform.parent = collision.transform;

        if(isPickable == true) {
            gameObject.layer = LayerMask.NameToLayer("Pickable");
            GetComponent<Collider2D>().isTrigger = true;
        }
    }

    private void Explode() {
        if(explosion != null) {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
        }
    }
}
