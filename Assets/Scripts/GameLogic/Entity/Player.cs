using System.Collections.Generic;

namespace Assets.Scripts.GameLogic.Entity
{
    public class Player : Person
    {
        public static readonly Player Player1 = new Player(1, "PLAYER 1");
        public static readonly Player Player2 = new Player(2, "PLAYER 2");
        public static readonly Player Player3 = new Player(3, "PLAYER 3");
        public static readonly Player Player4 = new Player(4, "PLAYER 4");
        public static readonly Player Player5 = new Player(5, "PLAYER 5");
        public static readonly Player Player6 = new Player(6, "PLAYER 6");

        public Player()
        {
        }

        public Player(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Player(int id, string name, PlayerColor playerColor)
        {
            Id = id;
            Name = name;
            PlayerColor = playerColor;
        }

        public static IEnumerable<Player> Values
        {
            get
            {
                yield return Player1;
                yield return Player2;
                yield return Player3;
                yield return Player4;
                yield return Player5;
                yield return Player6;
            }
        }

        public Player FindById(int id)
        {
            foreach (Player p in Values)
            {
                if (p.Id.Equals(id))
                {
                    return p;
                }
            }

            return null;
        }

        #region Getters and Setters

        public int Id { get; set; }

        public string Name { get; set; }

        public BoardSlot BoardSlot { get; set; }

        public PlayerColor PlayerColor { get; set; }

        #endregion
    }
}
