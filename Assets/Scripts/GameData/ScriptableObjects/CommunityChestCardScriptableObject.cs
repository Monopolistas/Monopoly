using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Community Chest Card")]
public class CommunityChestCardScriptableObject : ScriptableObject {
    public int id;
    public string text;
    public int value;
    public string transaction;
    public string cardAction;
    public int boardSlot;
    public int valuePerHouse;
    public int valuePerHotel;
}
