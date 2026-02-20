using System;
using UnityEngine;

public class CurrencyOffersGroupController : BaseOffersGroupController
{
    private ItemVisualData itemVisualData;

    public override void Init(Action<string> onInfoButtonClickAction)
    {
        PrepareItemVisualData(GameServices.ShopConfig.CurrencyIcon);

        base.Init(onInfoButtonClickAction);
    }

    protected override OfferData[] GetOffers()
    {
        return GameServices.ShopConfig.CurrencyOffers;
    }

    protected override ItemVisualData GetItemVisualForOffers(OfferData offerData)
    {
        return itemVisualData;
    }

    private void PrepareItemVisualData(Sprite currencyImage)
    {
        itemVisualData = new ItemVisualData();
        itemVisualData.Icon = currencyImage;
    }
}
