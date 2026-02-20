using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private ShopConfig shopConfig;
    [SerializeField] private DescriptionShower descriptionShower;
    [SerializeField] private BaseOffersGroupController[] offersGroupControllers;
    [SerializeField] private RectTransform layoutRoot;
    [SerializeField] private PurchaseFeedbackScreen purchaseFeedbackScreen;

    private Action<string> onInfoButtonClickAction;

    private void Awake()
    {
        onInfoButtonClickAction += descriptionShower.Show;
        GameServices.PurchasingService.OnPurchaseCompleted += CallLayoutRebuild;

        LoadOffers();
        StartCoroutine(ForceRebuildLayoutCall());
    }

    private void LoadOffers()
    {
        for (int i = 0; i < offersGroupControllers.Length; i++)
        {
            offersGroupControllers[i].Init(onInfoButtonClickAction);
        }
    }

    private void CallLayoutRebuild(PurchasedOfferModel purchasedOfferModel)
    {
        StartCoroutine(ForceRebuildLayoutCall());
    }

    IEnumerator ForceRebuildLayoutCall()
    {
        yield return null;
        LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot);
    }
    private void OnDisable()
    {
        purchaseFeedbackScreen.gameObject.SetActive(false);
        descriptionShower.gameObject.SetActive(false);
    }
}
