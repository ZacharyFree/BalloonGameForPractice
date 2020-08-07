using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewBloon", menuName = "NewBloon")]
public class BloonProperties : BloonsInventoryData
{
    public int layers = 1;
    //private float baseSpeed = 1f;
    public float speedMultiplier;
    public float actualSpeed;
    public Color color;
    [Header("Balloon Immunities")]
    public bool poppedBySharp;
    public bool poppedByBomb;

}
