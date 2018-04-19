namespace Assets.Scripts.GameLogic.Entity
{
    public class TitleDeedCard : LotCard
    {
        #region Getters and Setters

        public int BuildingPrice { get; set; }

        public int Rent { get; set; }

        public int OneHouseRent { get; set; }

        public int TwoHousesRent { get; set; }

        public int ThreeHousesRent { get; set; }

        public int FourHousesRent { get; set; }

        public int HotelRent { get; set; }

        public GroupColor GroupColor { get; set; }

        #endregion
    }
}
