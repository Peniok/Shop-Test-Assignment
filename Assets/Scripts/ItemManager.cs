using UnityEngine;

public class ItemManager
{
    public void AddItem(OfferData itemData)
    {
        if(itemData.ItemType == ItemType.Character)
        {
            PlayerPrefs.SetString("PlayerCharacters",itemData.ItemId);
        }
        else if (itemData.ItemType == ItemType.Booster)
        {
            PlayerPrefs.SetString("PlayerBoosters", itemData.ItemId);
        }
        else if(itemData.ItemType == ItemType.Currency)
        {
            PlayerPrefs.SetInt("PlayerCurrency", PlayerPrefs.GetInt("PlayerCurrency") + (itemData as CurrencyOfferData).Value);
        }
    }
}
