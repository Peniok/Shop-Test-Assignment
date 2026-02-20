using System;
using UnityEngine;

public abstract class BaseOffersGroupController : MonoBehaviour
{
    [SerializeField] protected BaseOfferSlot offerSlotPrefab;
    [SerializeField] protected Transform offerSlotTransformParent;

    private Action onOfferHidedAction;
    private int hidedOffers;
    private int spawnedOffers;

    public virtual void Init(Action<string> onInfoButtonClickAction)
    {
        onOfferHidedAction += OnOfferHided;

        OfferData[] offers = GetOffers();

        for (int i = 0; i < offers.Length; i++)
        {
            if (offers[i].IsOneTimePurchasable == false || (GameServices.SavesManager.PurchasedOneTimeOffers.Contains(offers[i].OfferId) == false))
            {
                ItemVisualData itemVisualData = GetItemVisualForOffers(offers[i]);
                BaseOfferSlot baseOfferSlot = Instantiate(offerSlotPrefab, offerSlotTransformParent);
                baseOfferSlot.Setup(itemVisualData, offers[i], onInfoButtonClickAction, onOfferHidedAction);
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

    protected void OnOfferHided()
    {
        hidedOffers++;
        if (spawnedOffers == hidedOffers)
        {
            gameObject.SetActive(false);
        }
    }

    protected virtual ItemVisualData GetItemVisualForOffers(OfferData offerData)
    {
        return GameServices.ItemsConfig.GetItemVisualData(offerData.ItemId);
    }

    protected abstract OfferData[] GetOffers();
}
