using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{ 
    public GameObject droppedItemPrefab;
    public List<LootItemData> lootlist = new List<LootItemData>();
    // Start is called before the first frame update

    LootItemData GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<LootItemData> possibleItems = new List<LootItemData>();
        foreach (LootItemData item in lootlist)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if (possibleItems.Count > 0)
        {
            LootItemData droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        Debug.Log("Без лута");
        return null;
    }

    public void InstantiateLoot( Vector3 spawnPosition)
    {
        LootItemData droppedItem = GetDroppedItem();
        if (droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.icon;
            LootItem item = lootGameObject.GetComponent<LootItem>();
            item.m_data = droppedItem;
           
         /*  float dropForce = 200f;
            Vector2 dropDirection = new Vector2(Random.Range(- 1f, 1), Random.Range(-1f, 1));
            lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);*/
        }
    }
 
}
