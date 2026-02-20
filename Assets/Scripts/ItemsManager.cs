using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] private CurrencyManager currencyManager;
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
            currencyManager.AddCurrency((itemData as CurrencyOfferData).Value);
        }
    }
}
