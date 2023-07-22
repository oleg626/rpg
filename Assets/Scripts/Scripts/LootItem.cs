using Unity.VisualScripting;
using UnityEngine;


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
