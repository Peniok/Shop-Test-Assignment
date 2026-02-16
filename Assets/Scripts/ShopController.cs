using System;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private BaseOfferSlot baseOfferPrefab;
    [SerializeField] private BaseOfferSlot currencyOfferPrefab;
    [SerializeField] private BaseOfferSlot boosterOfferSlot;

    [SerializeField] private ShopConfig shopConfig;
    [SerializeField] private CurrencyManager currencyManager;
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
            Instantiate(baseOfferPrefab).Setup(shopConfig.GetItemVisualDataById(shopConfig.CharacterOffers[i].ItemId), shopConfig.CharacterOffers[i], onPurchaseClickAction, onInfoButtonClickAction);
        }
    }

    public void LoadBoosterOffers()
    {
        for (int i = 0; i < shopConfig.BoosterOffers.Length; i++)
        {
            Instantiate(boosterOfferSlot).Setup(shopConfig.GetItemVisualDataById(shopConfig.BoosterOffers[i].ItemId), shopConfig.BoosterOffers[i], onPurchaseClickAction, onInfoButtonClickAction);
        }
    }

    public void LoadCurrencyOffers()
    {
        for (int i = 0; i < shopConfig.CurrencyOffers.Length; i++)
        {
            Instantiate(currencyOfferPrefab).Setup(shopConfig.GetItemVisualDataById(shopConfig.CurrencyOffers[i].ItemId), shopConfig.CurrencyOffers[i], onPurchaseClickAction,onInfoButtonClickAction);
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
