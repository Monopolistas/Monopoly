namespace Assets.Scripts.GameLogic.Entity
{
    public class GameState
    {
        public GameState()
        {

        }

        public GameState(Player[] players, Player playerOnTurn, bool isGameOver)
        {
            PlayerOnTurn = playerOnTurn;
            Players = players;
            IsGameOver = isGameOver;
        }

        #region Getters and Setters

        public Player PlayerOnTurn { get; set; }

        public Player[] Players { get; set; }

        public bool IsGameOver { get; set; }

        #endregion
    }
}
