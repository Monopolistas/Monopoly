using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.StateMachine;
using UnityEngine;

namespace Assets.Scripts.GameView
{
    public class BoardView : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;

        public GameController GameController;
        private bool _playersCreated;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
        }

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            if (_gameStateMachine != null && _gameStateMachine.Board.PlayerList.Count > 0 && !_playersCreated)
            {
                for (int index = 0; index < _gameStateMachine.Board.PlayerList.Count; index++)
                {
                    Player player = _gameStateMachine.Board.PlayerList[index];
                    _playersCreated = true;
                    if (player.PlayerColor.Name.Equals(PlayerColor.Black.Name))
                    {
                        Instantiate(Resources.Load("Prefab/black"));
                    }
                    if (player.PlayerColor.Name.Equals(PlayerColor.White.Name))
                    {
                        Instantiate(Resources.Load("Prefab/white"));
                    }
                    if (player.PlayerColor.Name.Equals(PlayerColor.Red.Name))
                    {
                        Instantiate(Resources.Load("Prefab/red"));
                    }
                    if (player.PlayerColor.Name.Equals(PlayerColor.Green.Name))
                    {
                        Instantiate(Resources.Load("Prefab/green"));
                    }
                    if (player.PlayerColor.Name.Equals(PlayerColor.Blue.Name))
                    {
                        Instantiate(Resources.Load("Prefab/blue"));
                    }
                    if (player.PlayerColor.Name.Equals(PlayerColor.Yellow.Name))
                    {
                        Instantiate(Resources.Load("Prefab/yellow"));
                    }
                }
            }
            else
            {
                _gameStateMachine = GameController.GameStateMachine;
            }
        }
    }
}
