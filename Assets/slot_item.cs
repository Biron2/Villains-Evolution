using UnityEngine;
using UnityEngine.UI;

public class slot_item : MonoBehaviour
{
    private GameObject black_background, buy_countText, coin_text;
    [SerializeField] private Manager _Manager;
    private void Start()
    {
        if (!gameObject.name.Equals("slot5"))
        {
            black_background = transform.Find("black_image").gameObject;
            coin_text = transform.Find("price/coin_text").gameObject;
        }
        buy_countText = transform.Find("buy_count").gameObject;
    }
    void Update()
    {
        Update_slot_prices_text();
        Update_buy_count_text();
        if (gameObject.name.Equals("slot1") && _Manager.bitcoins >= _Manager.slot_price_1)
        {
            black_background.SetActive(false);
        }
        if (gameObject.name.Equals("slot1") && _Manager.bitcoins < _Manager.slot_price_1)
        {
            black_background.SetActive(true);
        }

        if (gameObject.name.Equals("slot2") && _Manager.bitcoins >= _Manager.slot_price_2)
        {
            black_background.SetActive(false);
        }
        if (gameObject.name.Equals("slot2") && _Manager.bitcoins < _Manager.slot_price_2)
        {
            black_background.SetActive(true);
        }

        if (gameObject.name.Equals("slot3") && _Manager.bitcoins >= _Manager.slot_price_3)
        {
            black_background.SetActive(false);
        }
        if (gameObject.name.Equals("slot3") && _Manager.bitcoins < _Manager.slot_price_3)
        {
            black_background.SetActive(true);
        }
        if (gameObject.name.Equals("slot4") && _Manager.bitcoins >= _Manager.slot_price_4)
        {
            black_background.SetActive(false);
        }
        if (gameObject.name.Equals("slot4") && _Manager.bitcoins < _Manager.slot_price_4)
        {
            black_background.SetActive(true);
        }
        if (gameObject.name.Equals("slot6") && _Manager.bitcoins >= _Manager.slot_price_6)
        {
            black_background.SetActive(false);
        }
        if (gameObject.name.Equals("slot6") && _Manager.bitcoins < _Manager.slot_price_6)
        {
            black_background.SetActive(true);
        }
        if (gameObject.name.Equals("slot7") && _Manager.bitcoins >= _Manager.slot_price_7)
        {
            black_background.SetActive(false);
        }
        if (gameObject.name.Equals("slot7") && _Manager.bitcoins < _Manager.slot_price_7)
        {
            black_background.SetActive(true);
        }
        if (gameObject.name.Equals("slot8") && _Manager.bitcoins >= _Manager.slot_price_8)
        {
            black_background.SetActive(false);
        }
        if (gameObject.name.Equals("slot8") && _Manager.bitcoins < _Manager.slot_price_8)
        {
            black_background.SetActive(true);
        }
        if (gameObject.name.Equals("slot9") && _Manager.bitcoins >= _Manager.slot_price_9)
        {
            black_background.SetActive(false);
        }
        if (gameObject.name.Equals("slot9") && _Manager.bitcoins < _Manager.slot_price_9)
        {
            black_background.SetActive(true);
        }

        if (gameObject.name.Equals("slot10") && _Manager.bitcoins >= _Manager.slot_price_10)
        {
            black_background.SetActive(false);
        }
        if (gameObject.name.Equals("slot10") && _Manager.bitcoins < _Manager.slot_price_10)
        {
            black_background.SetActive(true);
        }
    }
    public void Update_buy_count_text()
    {
        if (gameObject.name.Equals("slot1") && _Manager.slot_buy_count_1 != 0)
        {
            buy_countText.SetActive(true);
            buy_countText.GetComponent<Text>().text = "x" + _Manager.slot_buy_count_1.ToString();
        }
        if (gameObject.name.Equals("slot2") && _Manager.slot_buy_count_2 != 0)
        {
            buy_countText.SetActive(true);
            buy_countText.GetComponent<Text>().text = "x" + _Manager.slot_buy_count_2.ToString();
        }
        if (gameObject.name.Equals("slot3") && _Manager.slot_buy_count_3 != 0)
        {
            buy_countText.SetActive(true);
            buy_countText.GetComponent<Text>().text = "x" + _Manager.slot_buy_count_3.ToString();
        }
        if (gameObject.name.Equals("slot4") && _Manager.slot_buy_count_4 != 0)
        {
            buy_countText.SetActive(true);
            buy_countText.GetComponent<Text>().text = "x" + _Manager.slot_buy_count_4.ToString();
        }
        if (gameObject.name.Equals("slot5") && _Manager.slot_buy_count_5 != 0)
        {
            buy_countText.SetActive(true);
            buy_countText.GetComponent<Text>().text = "x" + _Manager.slot_buy_count_5.ToString();
        }
        if (gameObject.name.Equals("slot6") && _Manager.slot_buy_count_6 != 0)
        {
            buy_countText.SetActive(true);
            buy_countText.GetComponent<Text>().text = "x" + _Manager.slot_buy_count_6.ToString();
        }
        if (gameObject.name.Equals("slot7") && _Manager.slot_buy_count_7 != 0)
        {
            buy_countText.SetActive(true);
            buy_countText.GetComponent<Text>().text = "x" + _Manager.slot_buy_count_7.ToString();
        }
        if (gameObject.name.Equals("slot8") && _Manager.slot_buy_count_8 != 0)
        {
            buy_countText.SetActive(true);
            buy_countText.GetComponent<Text>().text = "x" + _Manager.slot_buy_count_8.ToString();
        }
        if (gameObject.name.Equals("slot9") && _Manager.slot_buy_count_9 != 0)
        {
            buy_countText.SetActive(true);
            buy_countText.GetComponent<Text>().text = "x" + _Manager.slot_buy_count_9.ToString();
        }

        if (gameObject.name.Equals("slot10") && _Manager.slot_buy_count_10 != 0)
        {
            buy_countText.SetActive(true);
            buy_countText.GetComponent<Text>().text = "x" + _Manager.slot_buy_count_10.ToString();
        }
    }
    public void Update_slot_prices_text()
    {
        if (gameObject.name.Equals("slot1"))
        {
            coin_text.GetComponent<Text>().text = _Manager.FormatNumberShort(_Manager.slot_price_1);
        }
        if (gameObject.name.Equals("slot2"))
        {
            coin_text.GetComponent<Text>().text = _Manager.FormatNumberShort(_Manager.slot_price_2);
        }
        if (gameObject.name.Equals("slot3"))
        {
            coin_text.GetComponent<Text>().text = _Manager.FormatNumberShort(_Manager.slot_price_3);
        }
        if (gameObject.name.Equals("slot4"))
        {
            coin_text.GetComponent<Text>().text = _Manager.FormatNumberShort(_Manager.slot_price_4);
        }
        if (gameObject.name.Equals("slot6"))
        {
            coin_text.GetComponent<Text>().text = _Manager.FormatNumberShort(_Manager.slot_price_6);
        }
        if (gameObject.name.Equals("slot7"))
        {
            coin_text.GetComponent<Text>().text = _Manager.FormatNumberShort(_Manager.slot_price_7);
        }
        if (gameObject.name.Equals("slot8"))
        {
            coin_text.GetComponent<Text>().text = _Manager.FormatNumberShort(_Manager.slot_price_8);
        }
        if (gameObject.name.Equals("slot9"))
        {
            coin_text.GetComponent<Text>().text = _Manager.FormatNumberShort(_Manager.slot_price_9);
        }
        if (gameObject.name.Equals("slot10"))
        {
            coin_text.GetComponent<Text>().text = _Manager.FormatNumberShort(_Manager.slot_price_10);
        }
    }
}
