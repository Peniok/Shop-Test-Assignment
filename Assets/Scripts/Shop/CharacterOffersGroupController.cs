using UnityEngine;

public class CharacterOffersGroupController : BaseOffersGroupController
{
    protected override OfferData[] GetOffers()
    {
        return GameServices.ShopConfig.CharacterOffers;
    }
}
