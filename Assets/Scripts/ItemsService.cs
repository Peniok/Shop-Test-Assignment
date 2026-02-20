using UnityEngine;

public class ItemsService
{
    public ItemsService()
    {
        GameServices.PurchasingService.OnPurchaseCompleted += AddItemFromOffer;
    }


    public void AddItemFromOffer(PurchasedOfferModel purchasedOfferModel)
    {
        if(purchasedOfferModel.OfferData.ItemType == ItemType.Character)
        {
            GameServices.SavesManager.AddPurchasedCharactersId(purchasedOfferModel.OfferData.ItemId);
        }
        else if (purchasedOfferModel.OfferData.ItemType == ItemType.Booster)
        {
            // Booster implementation Logic
        }
        else if(purchasedOfferModel.OfferData.ItemType == ItemType.Currency 
            && purchasedOfferModel.OfferData is CurrencyOfferData currencyOfferData)
        {
            GameServices.CurrencyManager.AddCurrency(currencyOfferData.Value);
        }
    }
}
