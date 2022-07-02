using UnityEngine;

public class ExitController : MonoBehaviour
{
    public int exitDirection;

    private GameObject mainCamera;
    private RoomController roomController;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        roomController = gameObject.GetComponentInParent<RoomController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            if(exitDirection == roomController.blockedDoor) {
                collision.transform.position = new Vector2(0, 0);
                mainCamera.transform.position = new Vector2(0, 0);
            } else if(exitDirection == 1) {
                collision.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y + 6);
                mainCamera.transform.position = new Vector2(roomController.transform.position.x, roomController.transform.position.y + 20);
            } else if(exitDirection == 2) {
                collision.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y - 6);
                mainCamera.transform.position = new Vector2(roomController.transform.position.x, roomController.transform.position.y - 20);
            } else if(exitDirection == 3) {
                collision.transform.position = new Vector2(collision.transform.position.x + 6, collision.transform.position.y);
                mainCamera.transform.position = new Vector2(roomController.transform.position.x + 20, roomController.transform.position.y);
            } else if(exitDirection == 4) {
                collision.transform.position = new Vector2(collision.transform.position.x - 6, collision.transform.position.y );
                mainCamera.transform.position = new Vector2(roomController.transform.position.x - 20, roomController.transform.position.y);
            }
        }
    }
}
