using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text levelText;
    public Text ammoCountText;
    public Text coinCountText;
    public Image ammoLoadingBar;

    private PlayerShootingController playerShootingController;

    // Start is called before the first frame update
    void Start()
    {
        playerShootingController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShootingController>();
    }

    // Update is called once per frame
    void Update()
    {
        setLevelText();
        setCountText(ammoCountText, PlayerInventoryController.arrowCount);
        setCountText(coinCountText, PlayerInventoryController.coinCount);
        setAmmoLoadingBar();
    }

    private void setCountText(Text countText, int value) {
        countText.text = "x " + value.ToString();
    }

    private void setLevelText() {
        levelText.text = "Level " + GameController.level.ToString();
    }

    private void setAmmoLoadingBar() {
        float reloadTime = playerShootingController.reloadTime;
        float fireRate = playerShootingController.fireRate;
        if((reloadTime) > 0) {
            ammoLoadingBar.rectTransform.sizeDelta = new Vector2(5, 30 - 30 / fireRate * reloadTime);
        }
    }
}
