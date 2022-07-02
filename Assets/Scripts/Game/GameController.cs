using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static int level = 1;

    public void RestartGame() {
        ResetInventory();
        level = 1;
        PlayerHealthController.maxHealth = 3;
        PlayerHealthController.currentHealth = 3;
        RoomSpawner.maxRoomsCap = 4;
        RoomSpawner.roomsCount = 0;
        SceneManager.LoadScene("SampleScene");
    }

    public void NextLevel() {
        level++;
        RoomSpawner.maxRoomsCap++;
        RoomSpawner.roomsCount = 0;
        SceneManager.LoadScene("SampleScene");
    }

    public void ResetInventory() {
        PlayerInventoryController.coinCount = 0;
        PlayerInventoryController.arrowCount = 3;
    }
}
