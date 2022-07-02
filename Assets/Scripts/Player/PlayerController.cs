using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        // Misc
        if(collision.gameObject.CompareTag("Coin")) {
            Destroy(collision.gameObject);
            PlayerInventoryController.coinCount++;
        }

        if(collision.gameObject.CompareTag("Heart")) {
            Destroy(collision.gameObject);
            PlayerHealthController.currentHealth++;
        }

        // Ammo
        if(collision.gameObject.CompareTag("Arrow")) {
            Destroy(collision.gameObject);
            PlayerInventoryController.arrowCount++;
        }
    }
}
