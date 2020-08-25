using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bacterium", menuName = "Bacterium")]
public class CellStats : ScriptableObject
{
    public int maxHP;

    public float speed;
    public float divisionSpeed;
}
