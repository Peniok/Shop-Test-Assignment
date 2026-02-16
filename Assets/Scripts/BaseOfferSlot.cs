using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseOfferSlot : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI nameText;
    [SerializeField] protected TextMeshProUGUI priceText;
    [SerializeField] protected Image iconImage;
    [SerializeField] protected Button purchaseButton;
    [SerializeField] protected Button infoButton;

    public virtual void Setup(ItemVisualData data, OfferData offerData, Action<OfferData> onPurchaseClicked, Action<string> infoButtonClicked)
    {
        nameText.text = data.ItemName;
        priceText.text = $"{offerData.Price} $";
        iconImage.sprite = data.Icon;

        purchaseButton.onClick.AddListener(() => onPurchaseClicked?.Invoke(offerData));
        infoButton.onClick.AddListener(() => infoButtonClicked?.Invoke(data.Description));
    }
}
