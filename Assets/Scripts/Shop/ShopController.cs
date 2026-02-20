using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private ShopConfig shopConfig;
    [SerializeField] private CurrencyManager currencyManager;
    [SerializeField] private ItemsConfig itemsConfig;
    [SerializeField] private ItemsManager itemManager;
    [SerializeField] private DescriptionShower descriptionShower;
    [SerializeField] private BaseOffersGroupController[] offersGroupControllers;
    [SerializeField] private RectTransform layoutRoot;
    [SerializeField] private PurchaseFeedbackScreen purchaseFeedbackScreen;

    private Action<OfferData, ItemVisualData> onPurchaseClickAction;
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
            offersGroupControllers[i].Init(itemsConfig, shopConfig, onPurchaseClickAction, onInfoButtonClickAction);
        }
    }


    private void OnPurchaseButtonClicked(OfferData offerData,ItemVisualData itemVisualData)
    {
        if(offerData.PriceType == PriceType.RealMoney && TrySpendRealMoney() 
            || (offerData.PriceType == PriceType.Currency && currencyManager.IfEnoughSpend(offerData.Price)))
        {
            itemManager.AddItem(offerData);

        }

        purchaseFeedbackScreen.ShowPurchase(itemVisualData);
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
