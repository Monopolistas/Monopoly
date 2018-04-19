using Assets.Scripts.GameData;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameDatabase : MonoBehaviour
    {
        private ResourcesLoader _resourcesLoader;

        public GameController GameController;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            _resourcesLoader = new ResourcesLoader
            {
                GameStateMachine = GameController.GameStateMachine
            };

            _resourcesLoader.LoadXmlDataFromUnity();

            _resourcesLoader.FillDatabase();
        }

    }
}
