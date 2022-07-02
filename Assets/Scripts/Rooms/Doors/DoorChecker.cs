using System.Collections.Generic;
using UnityEngine;

public class DoorChecker : MonoBehaviour
{
    public bool isDoor;
    public int doorDirection;

    private RoomController roomController;

    private void Start() {
        roomController = gameObject.GetComponentInParent<RoomController>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("DoorCheck")) {
            if(collision.GetComponent<DoorChecker>().isDoor == false && isDoor == true) {
                roomController.blockedDoor = doorDirection;
            }
        }
    }
}


