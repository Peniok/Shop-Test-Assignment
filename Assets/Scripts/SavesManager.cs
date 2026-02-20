using System.Collections.Generic;
using UnityEngine;

public class SavesManager : MonoBehaviour
{
    public List<int> PickedCharactersToBattle; // index of item in PurchasedCharactersList (working as uniqueItemIdLogic)
    public List<string> PurchasedCharactersId;

    public void AddCharacterToBattle(int indexOfNewPickedCharacter)
    {
        PickedCharactersToBattle.Insert(0, indexOfNewPickedCharacter);

        if (PickedCharactersToBattle.Count == 4) // Max Can be 3 Picked characters
        {
            PickedCharactersToBattle.RemoveAt(3);
        }
    }

    public void AddPurchasedCharactersId(string id)
    {
        PurchasedCharactersId.Add(id);

    }
}
