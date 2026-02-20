using System;
using UnityEngine;

public abstract class BaseOffersGroupController : MonoBehaviour
{
    [SerializeField] protected BaseOfferSlot offerSlotPrefab;
    [SerializeField] protected Transform offerSlotTransformParent;

    public virtual void Init(Action<string> onInfoButtonClickAction)
    {
        OfferData[] offers = GetOffers();

        int spawnedOffers = 0;

        for (int i = 0; i < offers.Length; i++)
        {
            if (offers[i].IsOneTimePurchasable == false || (GameServices.SavesManager.PurchasedOneTimeOffers.Contains(offers[i].OfferId) == false))
            {
                ItemVisualData itemVisualData = GetItemVisualForOffers(offers[i]);
                Instantiate(offerSlotPrefab, offerSlotTransformParent)
                    .Setup(itemVisualData, offers[i], onInfoButtonClickAction);
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
        return GameServices.ItemsConfig.GetItemVisualData(offerData.ItemId);
    }

    protected abstract OfferData[] GetOffers();
}
