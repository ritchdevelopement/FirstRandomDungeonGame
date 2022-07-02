using System.Collections.Generic;
using UnityEngine;

public class SellerController : MonoBehaviour
{
    [Header("Item lists")]
    public List<GameObject> commonItems = new List<GameObject>();
    public List<GameObject> uncommonItems = new List<GameObject>();
    public List<GameObject> rareItems = new List<GameObject>();
    public List<GameObject> epicItems = new List<GameObject>();
    public List<GameObject> legendaryItems = new List<GameObject>();

    private Transform dialog;
    private GameObject sellerWindow;
    private PlayerShootingController playerShootingController;

    void Start() {
        dialog = transform.Find("Dialog");
        playerShootingController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShootingController>();
        sellerWindow = GameObject.FindGameObjectWithTag("SellerWindow");
        sellerWindow.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            playerShootingController.canShoot = false;
            if(GameController.level < 2) {
                dialog.GetComponent<MeshRenderer>().enabled = true;
            }
            if(GameController.level >= 2) {
                sellerWindow.SetActive(true);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            playerShootingController.canShoot = true;
            if(GameController.level < 2) {
                dialog.GetComponent<MeshRenderer>().enabled = false;
            }
            if(GameController.level >= 2) {
                sellerWindow.SetActive(false);
            }
        }
    }

    public GameObject getItem() {
        // Common
        if(Random.value > 0.5) {
            return commonItems[Random.Range(0, commonItems.Count - 1)];
        }

        // Uncommon
        if(Random.value > 0.7) {
            return uncommonItems[Random.Range(0, uncommonItems.Count - 1)];
        }

        // Rare
        if(Random.value > 0.9) {
            return rareItems[Random.Range(0, rareItems.Count - 1)];
        }
        
        // Epic
        //if(Random.value >= 0.97) {
        //    return epicItems[Random.Range(0, epicItems.Count - 1)];
        //}

        // Legendary
        //if(Random.value > 0.99) {
        //    return legendaryItems[Random.Range(0, legendaryItems.Count - 1)];
        //}
        
        return getItem();
    }
}
