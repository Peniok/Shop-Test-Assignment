using System;
using UnityEngine;

public class CurrencyOffersGroupController : BaseOffersGroupController
{
    protected override OfferData[] GetOffers()
    {
        return GameServices.ShopConfig.CurrencyOffers;
    }

    protected override ItemVisualData GetItemVisualForOffers(OfferData offerData)
    {
        return GameServices.ItemsConfig.CurrencyItemVisualData;
    }
}
