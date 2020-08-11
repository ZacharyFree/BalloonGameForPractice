using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bloon Inventory", menuName = "Bloon Inventory")]

public class BloonsInventoryData : ScriptableObject
{
    public BloonProperties[] bloonProperties;
}
