using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionShower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(Hide);
    }
    public void Show(string text)
    {
        description.text = text;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
