using System.Collections.Generic;

namespace Assets.Scripts.GameLogic.Entity
{
    public class Lot
    {
        public static explicit operator Lot(TitleDeedCard v)
        {
            Lot lot = new Lot();
            lot.Name = v.Name;
            lot.GroupColor = v.GroupColor;
            lot.Price = v.Price;
            lot.LotCardId = v.Id;
            return lot;
        }

        public static explicit operator Lot(RailroadCard v)
        {
            Lot lot = new Lot();
            lot.Name = v.Name;
            lot.Price = v.Price;
            lot.LotCardId = v.Id;
            return lot;
        }

        public static explicit operator Lot(UtilityCard v)
        {
            Lot lot = new Lot();
            lot.Name = v.Name;
            lot.Price = v.Price;
            lot.LotCardId = v.Id;
            return lot;
        }

        #region Getters and Setters

        public string Name { get; set; }

        public GroupColor GroupColor { get; set; }

        public int Price { get; set; }

        public List<Building> BuildingList { get; set; }

        public Mortgage Mortgage { get; set; }

        public LotCard LotCard { get; set; }

        public int LotCardId { get; set; }

        #endregion
    }
}
