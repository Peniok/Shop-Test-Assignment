using System;
using UnityEngine;

public abstract class BaseOffersGroupController : MonoBehaviour
{
    [SerializeField] protected BaseOfferSlot offerSlotPrefab;
    [SerializeField] protected Transform offerSlotTransformParent;

    protected ItemsConfig itemsConfig;
    protected ShopConfig shopConfig;

    public virtual void Init(ItemsConfig itemsConfig, ShopConfig shopConfig, Action<OfferData, ItemVisualData> onPurchaseClickAction, Action<string> onInfoButtonClickAction)
    {
        this.shopConfig = shopConfig;
        this.itemsConfig = itemsConfig;

        OfferData[] offers = GetOffers();

        if (offers.Length > 0)
        {
            gameObject.SetActive(true);
        }
        else
        {
            return;
        }

        for (int i = 0; i < offers.Length; i++)
        {
            ItemVisualData itemVisualData = GetItemVisualForOffers(offers[i]);
            Instantiate(offerSlotPrefab, offerSlotTransformParent)
                .Setup(itemVisualData, offers[i], onPurchaseClickAction, onInfoButtonClickAction);
        }
    }

    protected virtual ItemVisualData GetItemVisualForOffers(OfferData offerData)
    {
        return itemsConfig.GetItemVisualDataById(offerData.ItemId);
    }

    protected abstract OfferData[] GetOffers();
}
