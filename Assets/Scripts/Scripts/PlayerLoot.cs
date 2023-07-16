using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerLoot : MonoBehaviour
{
    private Dictionary<string, LootItemData> m_loot = new Dictionary<string, LootItemData>();
    private Dictionary<string, int> m_loot_quantity;
    public int m_slots_number = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        LootItem item = other.GetComponent<LootItem>();
        if (item != null)
        {
            if (addLootItem(item.m_data))
                item.Collect();
        }
    }

    private bool addLootItem(LootItemData loot)
    {
        if (m_loot.ContainsKey(loot.itemName))
        {
            if (loot.itemType == ItemType.Weapon || loot.itemType == ItemType.Armor)
            {
                // don't collect, we have it already.
                return false;
            }
            else
            {
                m_loot[loot.itemName].itemQuantity += loot.itemQuantity;
                Debug.Log("Collected " + loot.itemQuantity + " " + loot.itemName + " total now " + m_loot[loot.itemName].itemQuantity);
                return true;
            }
        }
        else if (m_loot.Count < m_slots_number)
        {
            m_loot[loot.itemName] = loot;
            Debug.Log("Collected " + loot.itemName);
            return true;
        }
        return false;
    }
}
