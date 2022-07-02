using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void Start() {
        if(transform.position.x < 10 && transform.position.x > -10  && transform.position.y < 10 && transform.position.y > -10) {
            Destroy(gameObject);
        }
    }
}
