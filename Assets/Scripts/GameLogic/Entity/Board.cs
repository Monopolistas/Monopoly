using System.Collections.Generic;

namespace Assets.Scripts.GameLogic.Entity
{
    public class Board
    {
        public Board()
        {
            PlayerList = new List<Player>();
            BoardSlotList = new List<BoardSlot>();
            ChanceCardQueue = new Queue<ChanceCard>();
            CommunityChestCardQueue = new Queue<CommunityChestCard>();
            Bank = new Bank();
        }

        public void MovePlayerTo(Player player, int steps)
        {
            int fromIndex = FindIndexWherePlayerIs(player);
            int toIndex = FindNextIndexWherePlayerWillBe(fromIndex, steps);

            BoardSlotList[fromIndex].PlayerList.Remove(player);
            player.BoardSlot = BoardSlotList[toIndex];
            BoardSlotList[toIndex].PlayerList.Add(player);
        }

        private int FindNextIndexWherePlayerWillBe(int index, int steps)
        {
            int j = index;

            for (int i = 0; i < steps; i++)
            {
                if (j >= BoardSlotList.Count)
                {
                    j = 0;
                }
                j++;
            }

            return j;
        }

        public int FindIndexWherePlayerIs(Player player)
        {
            int index = 0;
            foreach (BoardSlot item in BoardSlotList)
            {
                if (item.Id.Equals(player.BoardSlot.Id))
                {
                    break;
                }
                index++;
            }
            return index;
        }

        #region Getters and Setters

        public List<Player> PlayerList { get; set; }

        public List<BoardSlot> BoardSlotList { get; set; }

        public Queue<ChanceCard> ChanceCardQueue { get; set; }

        public Queue<CommunityChestCard> CommunityChestCardQueue { get; set; }

        public Bank Bank { get; set; }

        #endregion
    }
}
