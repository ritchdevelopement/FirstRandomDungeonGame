using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthController : MonoBehaviour, IDamagable
{
    public static int currentHealth = 3;
    public static int maxHealth = 3;

    public UnityEvent onDiedEvent;

    private float flashTime = 0.1f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor = new Color32(255, 255, 255, 255);

    private void Awake() {
        if(onDiedEvent == null) {
            onDiedEvent = new UnityEvent();
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if(currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(int damage) {
        if(damage > 0) {
            FlashRed();
            currentHealth -= damage;
        }

        // Player, Enemy etc... just died?
        if(currentHealth <= 0) {
            onDiedEvent.Invoke();
        }
    }

    private void FlashRed() {
        spriteRenderer.color = Color.red;
        Invoke("ResetColor", flashTime);
    }

    private void ResetColor() {
        spriteRenderer.color = originalColor;
    }
}
