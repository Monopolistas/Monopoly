using System.IO;
using Assets.Scripts.GameData.Xml;
using Assets.Scripts.GameLogic.Entity;
using Assets.Scripts.GameLogic.StateMachine;
using UnityEngine;

namespace Assets.Scripts.GameData
{
    public class ResourcesLoader
    {
        private BoardSlot[] _boardSlotArray;

        private ChanceCard[] _chanceCardArray;

        private CommunityChestCard[] _communityChestCardArray;

        private RailroadCard[] _railroadCardArray;

        private TitleDeedCard[] _titleDeedCardArray;

        private UtilityCard[] _utilityCardArray;

        private GameStateMachine _gameStateMachine;

        public void FillDatabase()
        {
            foreach (BoardSlot item in _boardSlotArray)
            {
                _gameStateMachine.Database.BoardSlotDictionary.Add(item.Id, item);
            }

            foreach (ChanceCard item in _chanceCardArray)
            {
                _gameStateMachine.Database.CardDictionary.Add(item.Id, item);
                _gameStateMachine.Database.ChanceCardList.Add(item);
            }

            foreach (CommunityChestCard item in _communityChestCardArray)
            {
                _gameStateMachine.Database.CardDictionary.Add(item.Id, item);
                _gameStateMachine.Database.CommunityChestCardList.Add(item);
            }

            foreach (RailroadCard item in _railroadCardArray)
            {
                _gameStateMachine.Database.CardDictionary.Add(item.Id, item);
                _gameStateMachine.Database.RailroadCardList.Add(item);
                _gameStateMachine.Database.LotDictionary.Add(item.Id, (Lot)item);
            }

            foreach (TitleDeedCard item in _titleDeedCardArray)
            {
                _gameStateMachine.Database.CardDictionary.Add(item.Id, item);
                _gameStateMachine.Database.TitleDeedCardList.Add(item);
                _gameStateMachine.Database.LotDictionary.Add(item.Id, (Lot)item);
            }


            foreach (UtilityCard item in _utilityCardArray)
            {
                _gameStateMachine.Database.CardDictionary.Add(item.Id, item);
                _gameStateMachine.Database.UtilityCardList.Add(item);
                _gameStateMachine.Database.LotDictionary.Add(item.Id, (Lot)item);
            }
        }

        public void LoadXmlData()
        {
            string boardSlotXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\BoardSlot.xml");
            string chanceCardXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\ChanceCard.xml");
            string communityChestCardXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\CommunityChestCard.xml");
            string railroadCardXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\RailroadCard.xml");
            string titleDeedCardXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\TitleDeedCard.xml");
            string utilityCardXml = File.ReadAllText("C:\\Users\\schif\\Documents\\Unity\\Monopolistas\\Monopoly\\Assets\\Resources\\Xml\\UtilityCard.xml");

            ConvertXmlToArray(boardSlotXml, chanceCardXml, communityChestCardXml, railroadCardXml, titleDeedCardXml, utilityCardXml);
        }

        public void LoadXmlDataFromUnity()
        {
            string boardSlotXml = Resources.Load<TextAsset>("Xml/BoardSlot").text;
            string chanceCardXml = Resources.Load<TextAsset>("Xml/ChanceCard").text;
            string communityChestCardXml = Resources.Load<TextAsset>("Xml/CommunityChestCard").text;
            string railroadCardXml = Resources.Load<TextAsset>("Xml/RailroadCard").text;
            string titleDeedCardXml = Resources.Load<TextAsset>("Xml/TitleDeedCard").text;
            string utilityCardXml = Resources.Load<TextAsset>("Xml/UtilityCard").text;

            ConvertXmlToArray(boardSlotXml, chanceCardXml, communityChestCardXml, railroadCardXml, titleDeedCardXml, utilityCardXml);
        }

        public void ConvertXmlToArray(string boardSlotXml, string chanceCardXml, string communityChestCardXml, string railroadCardXml, string titleDeedCardXml, string utilityCardXml)
        {
            BoardSlotArray = BoardSlotXml.Deserialize(boardSlotXml).ToArray();
            ChanceCardArray = ChanceCardXml.Deserialize(chanceCardXml).ToArray();
            CommunityChestCardArray = CommunityChestCardXml.Deserialize(communityChestCardXml).ToArray();
            TitleDeedCardArray = TitleDeedCardXml.Deserialize(titleDeedCardXml).ToArray();
            RailroadCardArray = RailroadCardXml.Deserialize(railroadCardXml).ToArray();
            UtilityCardArray = UtilityCardXml.Deserialize(utilityCardXml).ToArray();
        }

        #region Getters and Setters

        public GameStateMachine GameStateMachine
        {
            get
            {
                return _gameStateMachine;
            }

            set
            {
                _gameStateMachine = value;
            }
        }

        public ChanceCard[] ChanceCardArray
        {
            get
            {
                return _chanceCardArray;
            }

            set
            {
                _chanceCardArray = value;
            }
        }

        public CommunityChestCard[] CommunityChestCardArray
        {
            get
            {
                return _communityChestCardArray;
            }

            set
            {
                _communityChestCardArray = value;
            }
        }

        public RailroadCard[] RailroadCardArray
        {
            get
            {
                return _railroadCardArray;
            }

            set
            {
                _railroadCardArray = value;
            }
        }

        public TitleDeedCard[] TitleDeedCardArray
        {
            get
            {
                return _titleDeedCardArray;
            }

            set
            {
                _titleDeedCardArray = value;
            }
        }

        public UtilityCard[] UtilityCardArray
        {
            get
            {
                return _utilityCardArray;
            }

            set
            {
                _utilityCardArray = value;
            }
        }

        public BoardSlot[] BoardSlotArray
        {
            get
            {
                return _boardSlotArray;
            }

            set
            {
                _boardSlotArray = value;
            }
        }

        #endregion
    }
}
