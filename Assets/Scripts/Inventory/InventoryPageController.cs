using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPageController : MonoBehaviour
{
    [SerializeField] private SavesManager savesManager;
    [SerializeField] private ItemsConfig itemsConfig;
    [SerializeField] private ItemSlot itemSlotPrefab;

    private Action<string> onItemChoosedAction;
    private Action<string> onInfoButtonClickAction;

    private List<ItemSlot> allItems = new List<ItemSlot>();

    private Transform itemsHolder;

    private void Awake()
    {
        SpawnItems();
    }

    private void SpawnItems()
    {
        for (int i = 0; i < savesManager.PurchasedCharacters.Count; i++)
        {
            ItemSlot itemSlot = Instantiate(itemSlotPrefab, itemsHolder);
            itemSlot.Setup(itemsConfig.GetItemVisualDataById(savesManager.PurchasedCharacters[i]), savesManager.PurchasedCharacters[i], onInfoButtonClickAction, onItemChoosedAction);
            allItems.Add(itemSlot);
        }
    }
}
