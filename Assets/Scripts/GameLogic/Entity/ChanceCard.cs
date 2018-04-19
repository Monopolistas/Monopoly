namespace Assets.Scripts.GameLogic.Entity
{
    public class ChanceCard : Card
    {
        #region Getters and Setters

        public string Text { get; set; }

        public int Value { get; set; }

        public TransactionType TransactionType { get; set; }

        public CardActionType CardActionType { get; set; }

        public BoardSlot BoardSlot { get; set; }

        public int Multiplier { get; set; }

        public BoardSlotType BoardSlotType { get; set; }

        public int ValuePerHouse { get; set; }

        public int ValuePerHotel { get; set; }

        public int BoardSlotId { get; set; }

        #endregion
    }
}
