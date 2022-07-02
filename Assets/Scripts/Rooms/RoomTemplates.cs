using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomTemplates : MonoBehaviour
{
    [Header("Room Templates")]
    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;
    public GameObject connector;

    [Header("Enemies")]
    public GameObject[] smallEnemies;
    public GameObject[] bigEnemies;
    public GameObject[] bossEnemies;

    [Header("Misc")]
    public GameObject portal;

    [Header("Spawned Rooms List")]
    public List<GameObject> spawnedRooms = new List<GameObject>();

    [Header("On Events")]
    public UnityEvent onRoomsClearedEvent;

    private List<GameObject> clearedRooms = new List<GameObject>();
    private RoomController roomController;

    [HideInInspector] public bool isPortalCreated = false;

    private void Awake() {
        if(onRoomsClearedEvent == null) {
            onRoomsClearedEvent = new UnityEvent();
        }
        if(GameController.level == 1) {
            RoomController.minEnemyCap = 1;
            RoomController.maxEnemyCap = 2;
        } else if((GameController.level % 5) == 0) {
            RoomController.maxEnemyCap++;
        } else if((GameController.level % 10) == 0) {
            RoomController.minEnemyCap++;
        }
    }

    private void Update() {
        foreach(GameObject room in spawnedRooms) {
            if(room != null) {
                roomController = room.GetComponent<RoomController>();
                if(roomController.isActive == true) {
                    for(int i = 0; i < roomController.enemyCount; i++) {
                        GameObject randEnemy = RandomEnemy();
                        Vector2 roomCenter = roomController.transform.position;
                        Vector2 enemySpawnPosition = new Vector2(roomCenter.x + Random.Range(-5.5f, 5.5f), roomCenter.y + Random.Range(-5.5f, 5.5f));
                        GameObject spawnedEnemy = Instantiate(randEnemy, enemySpawnPosition, Quaternion.identity);
                        spawnedEnemy.transform.parent = roomController.transform;
                        roomController.enemyCount--;
                    }
                    if(!clearedRooms.Contains(room) && roomController.isCleared) {
                        clearedRooms.Add(room);
                    }
                }
            }
        }
        if(clearedRooms.Count >= RoomSpawner.maxRoomsCap) {
            onRoomsClearedEvent.Invoke();
            if(!isPortalCreated) {
                if(clearedRooms.Count > 0) {
                    GameObject lastClearedRoom = clearedRooms[clearedRooms.Count - 1];
                    Instantiate(portal, lastClearedRoom.transform.position, Quaternion.identity);
                    isPortalCreated = true;
                }
            }
        }
    }

    private GameObject RandomEnemy() {
        if(Random.value > 0.25) {
            return smallEnemies[Random.Range(0, smallEnemies.Length)];
        } else if(Random.value > 0.75) {
            return bigEnemies[Random.Range(0, bigEnemies.Length)];
        } else if(Random.value > 0.99 && GameController.level <= 4) {
            return bossEnemies[Random.Range(0, bossEnemies.Length)];
        } else if(Random.value > 0.98 && GameController.level >= 5) {
            return bossEnemies[Random.Range(0, bossEnemies.Length)];
        } else if(Random.value > 0.97 && GameController.level >= 10) {
            return bossEnemies[Random.Range(0, bossEnemies.Length)];
        } else if(Random.value > 0.96 && GameController.level >= 15) {
            return bossEnemies[Random.Range(0, bossEnemies.Length)];
        } else if(Random.value > 0.95 && GameController.level >= 20) {
            return bossEnemies[Random.Range(0, bossEnemies.Length)];
        }
        return RandomEnemy();
    }
}
