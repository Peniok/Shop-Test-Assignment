using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseFeedbackScreen : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Button closeButton;
    [SerializeField] private CanvasGroup canvasGroup;

    private void Awake()
    {
        GameServices.PurchasingService.OnPurchaseCompleted += ShowPurchase;
        closeButton.onClick.AddListener(Hide);
        canvasGroup.alpha = 1;
        Hide();
    }

    public void ShowPurchase(PurchasedOfferModel purchasedOfferModel)
    {
        gameObject.SetActive(true);
        image.sprite = purchasedOfferModel.ItemVisualData.Icon;
        nameText.text = purchasedOfferModel.ItemVisualData.ItemName;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
