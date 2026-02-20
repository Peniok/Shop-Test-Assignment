using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPageController : MonoBehaviour
{
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
        itemSlot.Setup(GameServices.ItemsConfig.GetItemVisualDataById(characterId), characterId, onInfoButtonClickAction, onCharacterChoosedAction);
        allItems.Add(itemSlot);
    }

    private void SpawnItems()
    {
        for (int i = 0; i < GameServices.SavesManager.PurchasedCharactersId.Count; i++)
        {
            AddItem(GameServices.SavesManager.PurchasedCharactersId[i]);
        }

        SetPickedCharcters();
    }

    private void SetPickedCharcters()
    {
        for (int i = 0; i < allItems.Count; i++)
        {
            if (GameServices.SavesManager.PickedCharactersToBattle.Contains(i))
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
        if (allItems.Count < GameServices.SavesManager.PurchasedCharactersId.Count)
        {
            for (int i = allItems.Count; i < GameServices.SavesManager.PurchasedCharactersId.Count; i++)
            {
                AddItem(GameServices.SavesManager.PurchasedCharactersId[i]);
            }
        }
    }

    private void PickCharacterToBattle(ItemSlot pickedItemSlot)
    {
        int indexOfNewPickedCharacter = allItems.IndexOf(pickedItemSlot);

        GameServices.SavesManager.AddCharacterToBattle(indexOfNewPickedCharacter);

        SetPickedCharcters();
    }

    private void OnDisable()
    {
        descriptionShower.Hide();
    }
}
