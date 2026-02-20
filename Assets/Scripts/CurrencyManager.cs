using System;
using TMPro;
using UnityEngine;

public class CurrencyManager
{
    public int Currency { get; private set; } = 1000;
    public Action<int> OnCurrencyAmountChanged;

    public bool IfEnoughSpend(int price)
    {
        if(Currency >= price)
        {
            Currency -= price;
            OnCurrencyAmountChanged.Invoke(Currency);
            return true;
        }
        return false;
    }

    public void AddCurrency(int amountOfAddedCurrency)
    {
        Currency += amountOfAddedCurrency;
        OnCurrencyAmountChanged.Invoke(Currency);
    }
}
