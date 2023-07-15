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
    public string itemName;
    public ItemType itemType;
    public Sprite icon; // The icon to represent the item in the UI
    public int itemLevel; // The level of the item (useful for scaling in RPG games)
    public int itemValue; // The value of the item, used for selling or trading
    public int itemQuantity;
    public int dropChance;
    // Add more properties like damage, defense, etc., depending on the ItemType

    // Constructor to initialize the LootItem with default values
    public LootItem()
    {
        itemName = "New Item";
        itemType = ItemType.Material;
        icon = null;
        itemLevel = 1;
        itemValue = 0;
        itemQuantity = 1;
        dropChance = 10;
    }

    // Constructor to initialize the LootItem with specific values
    public LootItem(string name, ItemType type, Sprite icon, int level, int value, int quantity, int chance)
    {
        itemName = name;
        itemType = type;
        this.icon = icon;
        itemLevel = level;
        itemValue = value;
        itemQuantity = quantity;
        dropChance = chance;
    }

    public void Collect()
    {
        Debug.Log(itemName + " Collected");
        Destroy(gameObject);
    }
}
