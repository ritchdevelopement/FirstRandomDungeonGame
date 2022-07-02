using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public int damage = 0;
    public bool collision = true;

    private void Start() {
        if(!collision) {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if(damagable != null) {
            damagable.TakeDamage(damage);
        }
    }
}
