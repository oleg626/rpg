using Unity.VisualScripting;
using UnityEngine;

// Enum to represent different types of loot items
public enum ItemType
{
    Weapon,
    Armor,
    Consumable,
    Material,
    // Add more item types as needed
}

[System.Serializable]
public class LootItem : MonoBehaviour, ICollectible
{
    public LootItemData m_data;

    public void Collect()
    {
        Debug.Log(m_data.itemName + " Collected");
        Destroy(gameObject);
    }
}
