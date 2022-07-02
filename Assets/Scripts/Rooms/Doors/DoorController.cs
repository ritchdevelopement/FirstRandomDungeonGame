using UnityEngine;

public class DoorController : MonoBehaviour
{
    private RoomController roomController;
    private int enemyCap;

    // Start is called before the first frame update
    void Start()    
    {
        roomController = gameObject.GetComponentInParent<RoomController>();
    }

    private void Update() {
        enemyCap = roomController.enemyCap;
        if(enemyCap < 1) {
            transform.DetachChildren();
            Destroy(gameObject);
        }
    }
}
