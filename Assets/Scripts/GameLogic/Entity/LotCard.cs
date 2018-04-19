namespace Assets.Scripts.GameLogic.Entity
{
    public class LotCard : Card
    {
        #region Getters and Setters

        public string Name { get; set; }

        public Lot Lot { get; set; }

        public int Mortgage { get; set; }

        public int Price { get; set; }

        #endregion
    }
}
