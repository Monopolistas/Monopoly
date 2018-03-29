using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Utility Card")]
public class UtilityCardScriptableObject : ScriptableObject {
    public new string name;
    public int id;
    public int price;
    public int rentWithOne;
    public int rentWithTwo;
    public int mortgage;
}
