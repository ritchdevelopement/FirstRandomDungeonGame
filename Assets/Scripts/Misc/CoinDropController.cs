using UnityEngine;

public class CoinDropController : MonoBehaviour
{
    public int minCoinDrop = 0;
    public int maxCoinDrop = 0;

    public GameObject coin;

    public void DropCoins() {
        int coinDropCount = Random.Range(minCoinDrop, maxCoinDrop + 1);
        for(int i = 0; i < coinDropCount; i++) {
            float rand = Random.Range(-0.5f, 0.5f);
            Vector2 randPosition = new Vector2(transform.position.x + rand, transform.position.y + rand);
            Instantiate(coin, randPosition, Quaternion.identity);
        }
    }
}
