using System.Collections.Generic;
using Assets.Scripts.GameUtil;

namespace Assets.Scripts.GameLogic.Entity
{
    public class Bank : Person
    {
        public Bank()
        {
            Cash = Constants.BankInitialCash;
            BuildingList = new List<Building>();
            LotCardList = new List<LotCard>();
        }

        #region Getters and Setters

        public List<Building> BuildingList { get; set; }

        public List<LotCard> LotCardList { get; set; }

        #endregion
    }
}
