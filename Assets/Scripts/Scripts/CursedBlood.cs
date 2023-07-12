using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedBlood : MonoBehaviour, ICollectible
{
   public void Collect()
    {
        Debug.Log("Кровь подобрана");
    }
}
