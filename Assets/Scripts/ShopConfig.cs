using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopConfig", menuName = "Shop/ShopConfig")]

public class ShopConfig : ScriptableObject
{
    public BoosterOfferData[] BoosterOffers;
    public CharacterOfferData[] CharacterOffers;
    public CurrencyOfferData[] CurrencyOffers;

    public List<ItemVisualDataForItemId> ItemVisualDataForItemId;

    public Sprite CurrencyIcon;

    public ItemVisualData GetItemVisualDataById(string itemId)
    {
        ItemVisualData itemVisualData = ItemVisualDataForItemId.Find(item => item.ItemId == itemId).VisualItemData;
        
        if(itemVisualData == null)
        {
            Debug.LogError("Add ItemVisual for " + itemId);
        }

        return itemVisualData;
    }
}
