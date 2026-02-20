using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] private CurrencyManager currencyManager;
    [SerializeField] private SavesManager savesManager;
    public void AddItem(OfferData itemData)
    {
        if(itemData.ItemType == ItemType.Character)
        {
            savesManager.AddPurchasedCharactersId(itemData.ItemId);
        }
        else if (itemData.ItemType == ItemType.Booster)
        {
            PlayerPrefs.SetString("PlayerBoosters", itemData.ItemId);
        }
        else if(itemData.ItemType == ItemType.Currency)
        {
            currencyManager.AddCurrency((itemData as CurrencyOfferData).Value);
        }
    }
}
