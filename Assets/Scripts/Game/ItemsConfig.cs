using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsConfig", menuName = "Scriptable Objects/ItemsConfig")]
public class ItemsConfig : ScriptableObject
{
    public List<UnitConfig> UnitsConfigs;
    public List<BoosterConfig> BoosterConfigs;

    public List<ItemVisualDataForItemId> ItemVisualDataForItemId;

    public UnitConfig GetUnitConfig(string id)
    {
        return UnitsConfigs.Find(config => config.ItemId == id);
    }

    public ItemVisualData GetItemVisualDataById(string itemId)
    {
        ItemVisualData itemVisualData = ItemVisualDataForItemId.Find(item => item.ItemId == itemId).VisualItemData;

        if (itemVisualData == null)
        {
            Debug.LogError("Add ItemVisual for " + itemId);
        }

        return itemVisualData;
    }
}

[Serializable]
public class UnitConfig
{
    public string ItemId;
    public PlayerUnitType UnitType;
    public int HP;
    public float Damage;
}

[Serializable]
public class BoosterConfig
{
    public string ItemId;
}

public enum PlayerUnitType
{
    Attacker,
    ArmoredProvoker
}