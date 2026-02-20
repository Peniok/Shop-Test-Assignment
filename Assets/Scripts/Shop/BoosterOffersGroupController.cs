using UnityEngine;

public class BoosterOffersGroupController : BaseOffersGroupController
{
    protected override OfferData[] GetOffers()
    {
        return shopConfig.BoosterOffers;
    }
}
