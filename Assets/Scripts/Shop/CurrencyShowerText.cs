using TMPro;
using UnityEngine;

public class CurrencyShowerText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;

    private void Start()
    {
        GameServices.CurrencyManager.OnCurrencyAmountChanged += ShowCurrency;
        ShowCurrency(GameServices.CurrencyManager.Currency);
    }

    private void ShowCurrency(int currency)
    {

        currencyText.text = currency.ToString();
    }
}
