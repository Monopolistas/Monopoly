using System.Collections.Generic;

namespace Assets.Scripts.GameLogic.Entity
{
    public class BoardSlot
    {
        public BoardSlot()
        {
            PlayerList = new List<Player>();
        }

        #region Getters and Setters

        public BoardSlotType BoardSlotType { get; set; }

        public int Id { get; set; }

        public int LotId { get; set; }

        public List<Player> PlayerList { get; set; }

        #endregion
    }
}