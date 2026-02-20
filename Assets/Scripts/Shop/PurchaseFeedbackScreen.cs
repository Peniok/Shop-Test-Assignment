using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseFeedbackScreen : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(Hide);
    }

    public void ShowPurchase(ItemVisualData itemVisualData)
    {
        gameObject.SetActive(true);
        image.sprite = itemVisualData.Icon;
        nameText.text = itemVisualData.ItemName;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
