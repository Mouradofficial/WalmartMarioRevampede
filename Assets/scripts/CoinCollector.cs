using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    public int coins = 0;
    public TMP_Text coinText;

    private void Start()
    {
        UpdateCoinUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            UpdateCoinUI();
            Destroy(other.gameObject); // Removes the coin
        }
    }

    void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = coins.ToString();
            // Optional: you can add a small UI pop animation here if you want
        }
    }
}
