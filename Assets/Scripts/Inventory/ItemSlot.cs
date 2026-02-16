using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI nameText;
    [SerializeField] protected Image iconImage;
    [SerializeField] protected GameObject selectedFrame;
    [SerializeField] protected Button infoButton;
    [SerializeField] protected Button itemChoosedButton;

    public virtual void Setup(ItemVisualData data, string id, Action<string> infoButtonClicked, Action<string> itemChoosedClicked)
    {
        nameText.text = data.ItemName;
        iconImage.sprite = data.Icon;

        infoButton.onClick.AddListener(() => infoButtonClicked?.Invoke(data.Description));
        itemChoosedButton.onClick.AddListener(() => itemChoosedClicked?.Invoke(id));
        itemChoosedButton.onClick.AddListener(SetPicked);

        selectedFrame.SetActive(true);
    }

    public void SetPicked()
    {
        selectedFrame.SetActive(true);
    }

    public void SetUnpicked()
    {
        selectedFrame.SetActive(false);
    }
}
