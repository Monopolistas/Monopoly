using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Board Slot", menuName = "Board Slot")]
public class BoardSlotScriptableObject : ScriptableObject {
    public int id;
    public int boardSlotType;
    public int lotId;
}
