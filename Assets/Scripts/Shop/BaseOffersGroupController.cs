using System;
using UnityEngine;

public abstract class BaseOffersGroupController : MonoBehaviour
{
    [SerializeField] protected BaseOfferSlot offerSlotPrefab;
    [SerializeField] protected Transform offerSlotTransformParent;

    protected ItemsConfig itemsConfig;
    protected ShopConfig shopConfig;

    public virtual void Init(SavesManager savesManager, ItemsConfig itemsConfig, ShopConfig shopConfig, Action<BaseOfferSlot> onPurchaseClickAction, Action<string> onInfoButtonClickAction)
    {
        this.shopConfig = shopConfig;
        this.itemsConfig = itemsConfig;

        OfferData[] offers = GetOffers();

        int spawnedOffers = 0;

        for (int i = 0; i < offers.Length; i++)
        {
            if (offers[i].IsOneTimePurchasable == false || (savesManager.PurchasedOneTimeOffers.Contains(offers[i].OfferId) == false))
            {
                ItemVisualData itemVisualData = GetItemVisualForOffers(offers[i]);
                Instantiate(offerSlotPrefab, offerSlotTransformParent)
                    .Setup(itemVisualData, offers[i], onPurchaseClickAction, onInfoButtonClickAction);
                spawnedOffers++;
            }
        }

        if (spawnedOffers > 0)
        {
            gameObject.SetActive(true);
        }
        else
        {
            return;
        }
    }

    protected virtual ItemVisualData GetItemVisualForOffers(OfferData offerData)
    {
        return itemsConfig.GetItemVisualDataById(offerData.ItemId);
    }

    protected abstract OfferData[] GetOffers();
}
