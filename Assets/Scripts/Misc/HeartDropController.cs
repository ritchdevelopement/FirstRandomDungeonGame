using UnityEngine;

public class HeartDropController : MonoBehaviour
{
    public int minHealthDrop = 0;
    public int maxHealthDrop = 0;
    public float dropChance = 0f;

    public GameObject heart;

    public void DropHearts() {
        if(Random.value > (100 - dropChance) / 100) {
            int healthDropCount = Random.Range(minHealthDrop, maxHealthDrop + 1);
            for(int i = 0; i < healthDropCount; i++) {
                Vector2 randPosition = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
                Instantiate(heart, randPosition, Quaternion.identity);
            }
        }
    }
}
