using System;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private BaseOfferSlot baseOfferPrefab;
    [SerializeField] private BaseOfferSlot currencyOfferPrefab;
    [SerializeField] private BaseOfferSlot boosterOfferSlot;
    [SerializeField] private Transform baseOfferTransformParent;
    [SerializeField] private Transform boosterOfferTransformParent;
    [SerializeField] private Transform currencyOfferTransformParent;

    [SerializeField] private ShopConfig shopConfig;
    [SerializeField] private CurrencyManager currencyManager;
    [SerializeField] private ItemsConfig itemsConfig;
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private DescriptionShower descriptionShower;

    private Action<OfferData> onPurchaseClickAction;
    private Action<string> onInfoButtonClickAction;

    private void Awake()
    {
        onPurchaseClickAction += OnPurchaseButtonClicked;
        onInfoButtonClickAction += descriptionShower.Show;

        LoadCharacterOffers();
        LoadBoosterOffers();
        LoadCurrencyOffers();
    }

    public void LoadCharacterOffers()
    {
        for (int i = 0; i < shopConfig.CharacterOffers.Length; i++)
        {
            Instantiate(baseOfferPrefab, baseOfferTransformParent).Setup(itemsConfig.GetItemVisualDataById(shopConfig.CharacterOffers[i].ItemId), shopConfig.CharacterOffers[i], onPurchaseClickAction, onInfoButtonClickAction);
        }
    }

    public void LoadBoosterOffers()
    {
        for (int i = 0; i < shopConfig.BoosterOffers.Length; i++)
        {
            Instantiate(boosterOfferSlot, boosterOfferTransformParent).Setup(itemsConfig.GetItemVisualDataById(shopConfig.BoosterOffers[i].ItemId), shopConfig.BoosterOffers[i], onPurchaseClickAction, onInfoButtonClickAction);
        }
    }

    public void LoadCurrencyOffers()
    {
        for (int i = 0; i < shopConfig.CurrencyOffers.Length; i++)
        {
            Instantiate(currencyOfferPrefab, currencyOfferTransformParent).Setup(itemsConfig.GetItemVisualDataById(shopConfig.CurrencyOffers[i].ItemId), shopConfig.CurrencyOffers[i], onPurchaseClickAction,onInfoButtonClickAction);
        }
    }

    private void OnPurchaseButtonClicked(OfferData offerData)
    {
        if (currencyManager.IfEnoughSpend(offerData.Price))
        {
            itemManager.AddItem(offerData);
        }
    }

    private void OnDestroy()
    {
        onPurchaseClickAction -= OnPurchaseButtonClicked;
    }
}
