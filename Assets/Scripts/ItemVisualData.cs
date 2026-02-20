using System;
using UnityEngine;

[Serializable]
public class ItemVisualData
{
    public string ItemId;
    public string ItemName;
    public Sprite Icon;
    [TextArea] public string Description;
}

public abstract class OfferData
{
    public string OfferId;
    public string ItemId;
    public bool IsOneTimePurchasable;
    public int Price;
    public PriceType PriceType;

    public abstract ItemType ItemType { get;}
}

[Serializable]
public class CurrencyOfferData : OfferData
{
    public override ItemType ItemType => ItemType.Currency;

    public int Value;
}

[Serializable]
public class CharacterOfferData : OfferData
{
    public override ItemType ItemType => ItemType.Character;
}

[Serializable]
public class BoosterOfferData : OfferData
{
    public override ItemType ItemType => ItemType.Booster;
}

public enum ItemType
{
    Character,
    Currency,
    Booster
}

public enum PriceType
{
    Currency,
    RealMoney
}
