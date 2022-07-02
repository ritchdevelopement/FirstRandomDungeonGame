using UnityEngine;

public class ArrowItemController : MonoBehaviour, IItem
{
    public int cost = 0;
    public bool unlocked = true;

    public int getItemCost() {
        return cost;
    }

    public bool getItemUnlocked() {
        return unlocked;
    }

    public void getItemEffect() {
        PlayerInventoryController.arrowCount++;
    }
}
