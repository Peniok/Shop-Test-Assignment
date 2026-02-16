using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPageController : MonoBehaviour
{
    [SerializeField] private SavesManager savesManager;
    [SerializeField] private ItemsConfig itemsConfig;
    [SerializeField] private ItemSlot itemSlotPrefab;

    private Action<string> onCharacterChoosedAction;
    private Action<string> onInfoButtonClickAction;

    private List<ItemSlot> allItems = new List<ItemSlot>();

    private Transform itemsHolder;

    private void Awake()
    {
        SpawnItems();
        onCharacterChoosedAction += PickCharacterToBattle;
    }

    private void SpawnItems()
    {
        for (int i = 0; i < savesManager.PurchasedCharactersId.Count; i++)
        {
            ItemSlot itemSlot = Instantiate(itemSlotPrefab, itemsHolder);
            itemSlot.Setup(itemsConfig.GetItemVisualDataById(savesManager.PurchasedCharactersId[i]), savesManager.PurchasedCharactersId[i], onInfoButtonClickAction, onCharacterChoosedAction);
            allItems.Add(itemSlot);
        }
    }

    private void PickCharacterToBattle(string characterId)
    {
        int indexOfNewPickedCharacter = savesManager.PurchasedCharactersId.FindIndex(id => id == characterId);
        if (savesManager.PurchasedCharactersId.Count == 3)
        {
            allItems[savesManager.PickedCharactersToBattle[0]].SetUnpicked();
        }

        savesManager.PickedCharactersToBattle.Insert(0, indexOfNewPickedCharacter);
        allItems[savesManager.PickedCharactersToBattle[0]].SetPicked();
    }

    public void AddItem()
    {

    }
}
