using UnityEngine;

public class RoomController : MonoBehaviour
{
    public static int minEnemyCap = 1;
    public static int maxEnemyCap = 2;
    [HideInInspector] public int blockedDoor;
    [HideInInspector] public int enemyCap;
    [HideInInspector] public int enemyCount;
    [HideInInspector] public bool isActive = false;
    public bool isCleared = false;

    private RoomTemplates roomTemplates;

    private void Awake() {
        enemyCap = Random.Range(minEnemyCap, maxEnemyCap + 1);
        enemyCount = enemyCap;
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        if(!gameObject.CompareTag("StartRoom") && gameObject != null) {
            roomTemplates.spawnedRooms.Add(gameObject);
        }
    }

    private void Update() {
        if(enemyCap <= 0) {
            isCleared = true;
        }   
    }
}
