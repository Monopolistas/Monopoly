using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Railroad Card")]
public class RailroadCardScriptableObject : ScriptableObject
{
    public new string name;
    public int id;
    public int price;
    public int rent;
    public int rentWithTwo;
    public int rentWithThree;
    public int rentWithFour;
    public int mortgage;
}
