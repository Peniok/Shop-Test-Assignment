using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopConfig", menuName = "Shop/ShopConfig")]

public class ShopConfig : ScriptableObject
{
    public BoosterOfferData[] BoosterOffers;
    public CharacterOfferData[] CharacterOffers;
    public CurrencyOfferData[] CurrencyOffers;
}
