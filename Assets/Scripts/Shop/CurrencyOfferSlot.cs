using System;
using TMPro;
using UnityEngine;

public class CurrencyOfferSlot : BaseOfferSlot
{
    [SerializeField] private TextMeshProUGUI amountOfCurrencyToReceive;

    public override void Setup(ItemVisualData data, OfferData offerData, Action<string> infoButtonClicked)
    {
        base.Setup(data, offerData, infoButtonClicked);
        if (offerData is CurrencyOfferData currencyOfferData)
        {
            amountOfCurrencyToReceive.text = "+" + currencyOfferData.Value.ToString();
        }
        else
        {
            Debug.LogError("Currency offers must be CurrencyOfferData type");
        }
    }
}
