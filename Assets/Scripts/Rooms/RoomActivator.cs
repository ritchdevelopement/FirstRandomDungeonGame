using UnityEngine;

public class RoomActivator : MonoBehaviour
{
    private RoomController roomController;

    private void Start() {
        roomController = gameObject.GetComponentInParent<RoomController>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            if(!roomController.isActive) {
                roomController.isActive = true;
            }
        }
    }
}
