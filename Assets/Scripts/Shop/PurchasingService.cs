using System;
using UnityEngine;

public class PurchasingService 
{
    public Action<PurchasedOfferModel> OnPurchaseCompleted;

    public bool TryPurchase(OfferData offerData, ItemVisualData itemVisualData)
    {
        if (offerData.PriceType == PriceType.RealMoney && TrySpendRealMoney()
            || (offerData.PriceType == PriceType.Currency && GameServices.CurrencyManager.IfEnoughSpend(offerData.Price)))
        {
            OnPurchaseCompleted.Invoke(new PurchasedOfferModel(offerData, itemVisualData));
            return true;
        }

        return false;
    }

    private static bool TrySpendRealMoney()
    {
        //Call to API for purchasing check
        return true;
    }
}

public class PurchasedOfferModel
{
    public OfferData OfferData { get; private set; }
    public ItemVisualData ItemVisualData { get; private set; }

    public PurchasedOfferModel(OfferData offerData, ItemVisualData itemVisualData)
    {
        OfferData = offerData;
        ItemVisualData = itemVisualData;
    }
}
