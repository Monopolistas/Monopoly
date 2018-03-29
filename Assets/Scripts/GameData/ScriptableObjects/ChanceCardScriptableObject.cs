using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Chance Card")]
public class ChanceCardScriptableObject : ScriptableObject {
    public int id;
    public string text;
    public int value;
    public string transaction;
    public string cardAction;
    public int boardSlot;
    public int multiplier;
    public int boardSlotType;
    public int valuePerHouse;
    public int valuePerHotel;
}
