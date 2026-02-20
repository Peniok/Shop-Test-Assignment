using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPageController : MonoBehaviour
{
    [SerializeField] private SavesManager savesManager;
    [SerializeField] private ItemsConfig itemsConfig;
    [SerializeField] private ItemSlot itemSlotPrefab;
    [SerializeField] private Transform itemSlotsParent;
    [SerializeField] private DescriptionShower descriptionShower;

    private Action<ItemSlot> onCharacterChoosedAction;
    private Action<string> onInfoButtonClickAction;

    private List<ItemSlot> allItems = new List<ItemSlot>();

    private void Awake()
    {
        onCharacterChoosedAction += PickCharacterToBattle;
        onInfoButtonClickAction += descriptionShower.Show;

        SpawnItems();
    }

    private void OnEnable()
    {
        SpawnNotEnoughItems();
    }

    public void AddItem(string characterId)
    {
        ItemSlot itemSlot = Instantiate(itemSlotPrefab, itemSlotsParent);
        itemSlot.Setup(itemsConfig.GetItemVisualDataById(characterId), characterId, onInfoButtonClickAction, onCharacterChoosedAction);
        allItems.Add(itemSlot);
    }

    private void SpawnItems()
    {
        for (int i = 0; i < savesManager.PurchasedCharactersId.Count; i++)
        {
            AddItem(savesManager.PurchasedCharactersId[i]);
        }

        SetPickedCharcters();
    }

    private void SetPickedCharcters()
    {
        for (int i = 0; i < allItems.Count; i++)
        {
            if (savesManager.PickedCharactersToBattle.Contains(i))
            {
                allItems[i].SetPicked();
            }
            else
            {
                allItems[i].SetUnpicked();
            }
        }
    }

    private void SpawnNotEnoughItems()
    {
        if (allItems.Count < savesManager.PurchasedCharactersId.Count)
        {
            for (int i = allItems.Count; i < savesManager.PurchasedCharactersId.Count; i++)
            {
                AddItem(savesManager.PurchasedCharactersId[i]);
            }
        }
    }

    private void PickCharacterToBattle(ItemSlot pickedItemSlot)
    {
        int indexOfNewPickedCharacter = allItems.IndexOf(pickedItemSlot);

        savesManager.AddCharacterToBattle(indexOfNewPickedCharacter);

        SetPickedCharcters();
    }

    private void OnDisable()
    {
        descriptionShower.Hide();
    }
}
