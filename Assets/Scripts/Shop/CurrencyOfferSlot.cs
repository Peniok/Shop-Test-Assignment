using System;
using TMPro;
using UnityEngine;

public class CurrencyOfferSlot : BaseOfferSlot
{
    [SerializeField] private TextMeshProUGUI amountOfCurrencyToReceive;

    public override void Setup(ItemVisualData data, OfferData offerData, Action<OfferData, ItemVisualData> onPurchaseClicked, Action<string> infoButtonClicked)
    {
        base.Setup(data, offerData, onPurchaseClicked, infoButtonClicked);

        amountOfCurrencyToReceive.text = "+" + (offerData as CurrencyOfferData).Value.ToString();
    }
}
