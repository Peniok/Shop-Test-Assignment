using System;
using UnityEngine;

public class CurrencyOffersGroupController : BaseOffersGroupController
{
    private ItemVisualData itemVisualData;

    public override void Init(SavesManager savesManager,ItemsConfig itemsConfig, ShopConfig shopConfig, Action<BaseOfferSlot> onPurchaseClickAction, Action<string> onInfoButtonClickAction)
    {
        PrepareItemVisualData(shopConfig.CurrencyIcon);

        base.Init(savesManager,itemsConfig, shopConfig, onPurchaseClickAction, onInfoButtonClickAction);
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
