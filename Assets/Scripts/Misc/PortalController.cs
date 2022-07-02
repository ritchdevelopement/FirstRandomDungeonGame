using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    private GameController gameController;

    private void Start() {
        gameController = GameObject.FindGameObjectWithTag("Game").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            gameController.NextLevel();
        }
    }
}
