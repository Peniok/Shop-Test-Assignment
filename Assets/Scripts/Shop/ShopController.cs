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

    private Action<OfferData> onPurchaseClickAction;
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


    private void OnPurchaseButtonClicked(OfferData offerData)
    {
        if(offerData.PriceType == PriceType.RealMoney && TrySpendRealMoney())
        {
            itemManager.AddItem(offerData);

        }
        else if(currencyManager.IfEnoughSpend(offerData.Price))
        {
            itemManager.AddItem(offerData);
        }
    }

    private bool TrySpendRealMoney()
    {
        //Call to API for purchasing check
        return true;
    }

    private void OnDestroy()
    {
        onPurchaseClickAction -= OnPurchaseButtonClicked;
    }
}
