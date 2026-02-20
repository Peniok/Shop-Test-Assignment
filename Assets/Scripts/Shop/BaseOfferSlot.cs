using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseOfferSlot : MonoBehaviour
{
    public OfferData OfferData { get; private set; }
    public ItemVisualData ItemVisualData { get; private set; }

    [SerializeField] protected TextMeshProUGUI nameText;
    [SerializeField] protected TextMeshProUGUI priceText;
    [SerializeField] protected Image iconImage;
    [SerializeField] protected Button purchaseButton;
    [SerializeField] protected Button infoButton;

    private Action onOfferHidedAction;

    public virtual void Setup(ItemVisualData visualData, OfferData offerData, Action<string> infoButtonClicked, Action onOfferHidedAction)
    {
        OfferData = offerData;
        ItemVisualData = visualData;

        this.onOfferHidedAction += onOfferHidedAction;

        nameText.text = visualData.ItemName;
        if(offerData.PriceType == PriceType.Currency)
        {
            priceText.text = $"{offerData.Price} <sprite index=0>";
        }
        else
        {
            priceText.text = $"{offerData.Price} $";
        }
        iconImage.sprite = visualData.Icon;

        purchaseButton.onClick.AddListener(OnPurchaseButtonClicked);
        infoButton.onClick.AddListener(() => infoButtonClicked?.Invoke(visualData.Description));
    }

    private void OnPurchaseButtonClicked()
    {
        if(GameServices.PurchasingService.TryPurchase(OfferData, ItemVisualData) && OfferData.IsOneTimePurchasable)
        {
            gameObject.SetActive(false);
            onOfferHidedAction.Invoke();
        }
    }
}
