using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;

    private int currency=1000;

    private void Awake()
    {
        currencyText.text = currency.ToString();
    }

    public bool IfEnoughSpend(int price)
    {
        if(currency >= price)
        {
            currency -= price;
            currencyText.text = currency.ToString();
            return true;
        }
        return false;
    }

    public void AddCurrency(int amountOfAddedCurrency)
    {
        currency += amountOfAddedCurrency;
        currencyText.text = currency.ToString();
    }
}
