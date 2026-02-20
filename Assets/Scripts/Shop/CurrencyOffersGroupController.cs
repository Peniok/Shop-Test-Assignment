using System;
using UnityEngine;

public class CurrencyOffersGroupController : BaseOffersGroupController
{
    private ItemVisualData itemVisualData;

    public override void Init(ItemsConfig itemsConfig, ShopConfig shopConfig, Action<OfferData> onPurchaseClickAction, Action<string> onInfoButtonClickAction)
    {
        PrepareItemVisualData(shopConfig.CurrencyIcon);

        base.Init(itemsConfig, shopConfig, onPurchaseClickAction, onInfoButtonClickAction);
    }

    protected override OfferData[] GetOffers()
    {
        return shopConfig.CurrencyOffers;
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
