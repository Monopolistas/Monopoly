using Assets.Scripts.GameLogic.StateMachine;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {

        public GameStateMachine GameStateMachine;

        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            GameStateMachine = new GameStateMachine();
        }

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            GameStateMachine.ExecuteGameLogic();
        }

    }
}
