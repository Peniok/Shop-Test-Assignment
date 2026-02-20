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
    public virtual void Setup(ItemVisualData visualData, OfferData offerData, Action<BaseOfferSlot> onPurchaseClicked, Action<string> infoButtonClicked)
    {
        OfferData = offerData;
        ItemVisualData = visualData;

        nameText.text = visualData.ItemName;
        priceText.text = $"{offerData.Price} $";
        iconImage.sprite = visualData.Icon;

        purchaseButton.onClick.AddListener(() => onPurchaseClicked?.Invoke(this));
        infoButton.onClick.AddListener(() => infoButtonClicked?.Invoke(visualData.Description));
    }

}
