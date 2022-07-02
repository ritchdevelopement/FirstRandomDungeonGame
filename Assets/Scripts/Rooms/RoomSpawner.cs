using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    private RoomSpawner[] roomSpawners;
    private RoomTemplates roomTemplates;
    private GameObject[] topRoomTemplates;
    private GameObject[] bottomRoomTemplates;
    private GameObject[] rightRoomTemplates;
    private GameObject[] leftRoomTemplates;
    private GameObject connectorRoomTemplate;
    private GameObject room;

    public static int maxRoomsCap = 4; // maxRoomsCap % 4 = 0
    public static int roomsCount = 0;

    public bool spawned = false;
    public int openingDirection;
    // 1 = bottom door
    // 2 = need top door
    // 3 = need left door
    // 4 = need right door

    private List<GameObject> allowedRooms = new List<GameObject>();

    private float timeToDestroy = 5f;

    private void Start() {
        Destroy(gameObject, timeToDestroy);
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        topRoomTemplates = roomTemplates.topRooms;
        bottomRoomTemplates = roomTemplates.bottomRooms;
        rightRoomTemplates = roomTemplates.rightRooms;
        leftRoomTemplates = roomTemplates.leftRooms;
        connectorRoomTemplate = roomTemplates.connector;
        Invoke("Spawn", 0.1f);
    }

    public void Spawn() {
        if(spawned == false) {
            if (openingDirection == 1) {
                filterAllowedRooms(bottomRoomTemplates);
                room = getRandomAllowedRoom();
                Instantiate(room, transform.position, room.transform.rotation);
                roomsCount++;
            } else if (openingDirection == 2) {
                filterAllowedRooms(topRoomTemplates);
                room = getRandomAllowedRoom();
                Instantiate(room, transform.position, room.transform.rotation);
                roomsCount++;
            } else if (openingDirection == 3) {
                filterAllowedRooms(leftRoomTemplates);
                room = getRandomAllowedRoom();
                Instantiate(room, transform.position, room.transform.rotation);
                roomsCount++;
            } else if (openingDirection == 4) {
                filterAllowedRooms(rightRoomTemplates);
                room = getRandomAllowedRoom();
                Instantiate(room, transform.position, room.transform.rotation);
                roomsCount++;
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("SpawnPoint")) {
            if(collision.GetComponent<RoomSpawner>().spawned == false && spawned == false) {
                Instantiate(connectorRoomTemplate, transform.position, connectorRoomTemplate.transform.rotation);
            }
            spawned = true;
        }
    }

    private void filterAllowedRooms(GameObject[] roomTemplates) {
        foreach(GameObject roomTemplate in roomTemplates) {
            roomSpawners = roomTemplate.GetComponentsInChildren<RoomSpawner>();
            if(roomSpawners.Length < 2 && roomsCount < maxRoomsCap - 4) {
                continue;
            } else if(roomSpawners.Length > 1 && roomsCount >= maxRoomsCap - 4) {
                continue;
            }
            allowedRooms.Add(roomTemplate);
        }
    }

    private GameObject getRandomAllowedRoom() {
        return allowedRooms[Random.Range(0, allowedRooms.Count)];
    }
}
