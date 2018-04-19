using System.Collections.Generic;

namespace Assets.Scripts.GameLogic.Entity
{
    public class PlayerTurn
    {
        public PlayerTurn()
        {
            DiceThrowList = new List<DiceThrow>();
        }

        public void AddDiceThrow(DiceThrow diceThrow)
        {
            DiceThrowList.Add(diceThrow);
        }

        public bool IsThirdThrow()
        {
            return (DiceThrowList.Count >= 3);
        }

        public Player Player { get; set; }

        public List<DiceThrow> DiceThrowList { get; set; }
    }
}
