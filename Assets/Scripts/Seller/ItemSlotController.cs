using UnityEngine;
using UnityEngine.UI;

public class ItemSlotController : MonoBehaviour
{
    private Image itemImage;
    private Text coinText;
    private GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        itemImage = transform.Find("ItemImage").GetComponent<Image>();
        coinText = transform.Find("CoinText").GetComponent<Text>();
        item = GameObject.FindGameObjectWithTag("Seller").GetComponent<SellerController>().getItem();
        setItem();
    }

    public void removeItem() {
        if(PlayerInventoryController.coinCount >= item.GetComponent<IItem>().getItemCost()) {
            itemImage.sprite = null;
            Color itemImageColor = itemImage.color;
            itemImageColor.a = 0f;
            itemImage.color = itemImageColor;
            item.GetComponent<IItem>().getItemEffect();
            PlayerInventoryController.coinCount -= item.GetComponent<IItem>().getItemCost();
            coinText.text = "-";
        }
    }

    public void setItem() {
        itemImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
        coinText.text = item.GetComponent<IItem>().getItemCost().ToString();
    }
}
