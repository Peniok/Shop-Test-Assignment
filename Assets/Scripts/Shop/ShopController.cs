using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private ShopConfig shopConfig;
    [SerializeField] private SavesManager savesManager;
    [SerializeField] private CurrencyManager currencyManager;
    [SerializeField] private ItemsConfig itemsConfig;
    [SerializeField] private ItemsManager itemManager;
    [SerializeField] private DescriptionShower descriptionShower;
    [SerializeField] private BaseOffersGroupController[] offersGroupControllers;
    [SerializeField] private RectTransform layoutRoot;
    [SerializeField] private PurchaseFeedbackScreen purchaseFeedbackScreen;

    private Action<BaseOfferSlot> onPurchaseClickAction;
    private Action<string> onInfoButtonClickAction;

    private void Awake()
    {
        onPurchaseClickAction += OnPurchaseButtonClicked;
        onInfoButtonClickAction += descriptionShower.Show;

        LoadOffers();
        StartCoroutine(ForceRebuildLayoutCall());
    }

    IEnumerator ForceRebuildLayoutCall()
    {
        yield return null;
        LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot);
    }

    private void LoadOffers()
    {
        for (int i = 0; i < offersGroupControllers.Length; i++)
        {
            offersGroupControllers[i].Init(savesManager,itemsConfig, shopConfig, onPurchaseClickAction, onInfoButtonClickAction);
        }
    }


    private void OnPurchaseButtonClicked(BaseOfferSlot baseOfferSlot)
    {
        if(baseOfferSlot.OfferData.PriceType == PriceType.RealMoney && TrySpendRealMoney() 
            || (baseOfferSlot.OfferData.PriceType == PriceType.Currency && currencyManager.IfEnoughSpend(baseOfferSlot.OfferData.Price)))
        {
            itemManager.AddItem(baseOfferSlot.OfferData);

            purchaseFeedbackScreen.ShowPurchase(baseOfferSlot.ItemVisualData);

            if (baseOfferSlot.OfferData.IsOneTimePurchasable)
            {
                savesManager.AddPurchasedOffer(baseOfferSlot.OfferData.OfferId);
                baseOfferSlot.gameObject.SetActive(false);
                StartCoroutine(ForceRebuildLayoutCall());
            }
        }
    }

    private bool TrySpendRealMoney()
    {
        //Call to API for purchasing check
        return true;
    }
    private void OnDisable()
    {
        purchaseFeedbackScreen.gameObject.SetActive(false);
        descriptionShower.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        onPurchaseClickAction -= OnPurchaseButtonClicked;
    }

}
