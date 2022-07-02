using UnityEngine;
using UnityEngine.UI;

public class PlayerHeartsController : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Update is called once per frame
    void Update()
    {

        for(int i = 0; i < hearts.Length; i++) {
            if(i < PlayerHealthController.currentHealth) {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }

            if(i < PlayerHealthController.maxHealth) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }
}
