using System.Collections.Generic;
using UnityEngine;

public class SavesManager
{
    public List<int> PickedCharactersToBattle = new List<int>(); // index of item in PurchasedCharactersList (working as uniqueItemIdLogic)
    public List<string> PurchasedCharactersId = new List<string>();
    public List<string> PurchasedOneTimeOffers = new List<string>();

    public static int MaxCountOfPickedCharacters = 3;

    public SavesManager()
    {
        GameServices.PurchasingService.OnPurchaseCompleted += OnPurchaseComplete;
    }

    public void AddCharacterToBattle(int indexOfNewPickedCharacter)
    {
        PickedCharactersToBattle.Insert(0, indexOfNewPickedCharacter);

        if (PickedCharactersToBattle.Count == (MaxCountOfPickedCharacters + 1))
        {
            PickedCharactersToBattle.RemoveAt(3);
        }
    }

    public void AddPurchasedCharactersId(string id)
    {
        PurchasedCharactersId.Add(id);
    }

    public void OnPurchaseComplete(PurchasedOfferModel purchasedOfferModel)
    {
        if (purchasedOfferModel.OfferData.IsOneTimePurchasable)
        {
            PurchasedOneTimeOffers.Add(purchasedOfferModel.OfferData.OfferId);
        }

    }
}
