using System;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenUIController : MonoBehaviour
{
    [SerializeField] private Button shopPageButton;
    [SerializeField] private Button inventoryPageButton;
    [SerializeField] private Button mainPageButton;
    [SerializeField] private Button startBattleButton;
    [SerializeField] private GameObject shopPage;
    [SerializeField] private GameObject mainPage;
    [SerializeField] private GameObject inventoryPage;
    [SerializeField] private BattleManager battleScenePrefab;
    [SerializeField] private SavesManager savesManager;

    [SerializeField] private Button startLevel;

    private Action onBattleEndedAction;

    private void Awake()
    {
        mainPageButton.onClick.AddListener(EnableMainPage);
        shopPageButton.onClick.AddListener(EnableShopPage);
        inventoryPageButton.onClick.AddListener(EnableInventoryPage);
        startBattleButton.onClick.AddListener(StartBattle);

        onBattleEndedAction += EnableMainPage;
    }

    private void EnableMainPage()
    {
        mainPage.SetActive(true);
        shopPage.SetActive(false);
        inventoryPage.SetActive(false);
    }

    private void EnableShopPage()
    {
        mainPage.SetActive(false);
        shopPage.SetActive(true);
        inventoryPage.SetActive(false);
    }

    private void EnableInventoryPage()
    {
        mainPage.SetActive(false);
        shopPage.SetActive(false);
        inventoryPage.SetActive(true);
    }

    private void StartBattle()
    {
        Instantiate(battleScenePrefab).Init(onBattleEndedAction, savesManager.PurchasedCharactersId, savesManager.PickedCharactersToBattle);
        startBattleButton.gameObject.SetActive(false);
        shopPage.SetActive(false);
        inventoryPage.SetActive(false);
    }
}
