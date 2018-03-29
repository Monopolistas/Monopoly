using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Title Deed Card")]
public class TitleDeedCardScriptableObject : ScriptableObject
{
    public new string name;
    public int id;
    public int price;
    public int rent;
    public int rentOneHouse;
    public int rentTwoHouses;
    public int rentThreeHouses;
    public int rentFourHouses;
    public int rentHotel;
    public int mortgage;
    public int buildingPrice;
    public string groupColor;

}
