using System.Collections.Generic;
using Assets.Scripts.GameLogic.Entity;

namespace Assets.Scripts.GameLogic
{
    public class VirtualDatabase
    {
        // Immutable collections
        private Dictionary<int, Card> _cardDictionary;
        private Dictionary<int, BoardSlot> _boardSlotDictionary;
        private Dictionary<int, Lot> _lotDictionary;
        private Queue<Player> _playerQueue;
        private Queue<PlayerColor> _playerColorQueue;
        private List<TitleDeedCard> _titleDeedCardList;
        private List<ChanceCard> _chanceCardList;
        private List<CommunityChestCard> _communityChestCardList;
        private List<RailroadCard> _railroadCardList;
        private List<UtilityCard> _utilityCardList;

        // Mutable
        private Dictionary<int, Player> _playerDictionary;

        public VirtualDatabase()
        {
            _cardDictionary = new Dictionary<int, Card>();
            _playerDictionary = new Dictionary<int, Player>();
            _boardSlotDictionary = new Dictionary<int, BoardSlot>();
            _lotDictionary = new Dictionary<int, Lot>();
            _playerQueue = new Queue<Player>(Player.Values);
            _playerColorQueue = new Queue<PlayerColor>(PlayerColor.Values);
            _titleDeedCardList = new List<TitleDeedCard>();
            _chanceCardList = new List<ChanceCard>();
            _communityChestCardList = new List<CommunityChestCard>();
            _railroadCardList = new List<RailroadCard>();
            _utilityCardList = new List<UtilityCard>();
        }

        #region Getters and Setters

        public Queue<Player> PlayerQueue
        {
            get
            {
                return _playerQueue;
            }
            set
            {
                _playerQueue = value;
            }
        }

        public Queue<PlayerColor> PlayerColorQueue
        {
            get
            {
                return _playerColorQueue;
            }
            set
            {
                _playerColorQueue = value;
            }
        }

        public Dictionary<int, Player> PlayerDictionary
        {
            get
            {
                return _playerDictionary;
            }
            set
            {
                _playerDictionary = value;
            }
        }

        public Dictionary<int, Card> CardDictionary
        {
            get
            {
                return _cardDictionary;
            }

            set
            {
                _cardDictionary = value;
            }
        }

        public Dictionary<int, BoardSlot> BoardSlotDictionary
        {
            get
            {
                return _boardSlotDictionary;
            }

            set
            {
                _boardSlotDictionary = value;
            }
        }

        public Dictionary<int, Lot> LotDictionary
        {
            get
            {
                return _lotDictionary;
            }

            set
            {
                _lotDictionary = value;
            }
        }

        public List<TitleDeedCard> TitleDeedCardList
        {
            get
            {
                return _titleDeedCardList;
            }

            set
            {
                _titleDeedCardList = value;
            }
        }

        public List<ChanceCard> ChanceCardList
        {
            get
            {
                return _chanceCardList;
            }

            set
            {
                _chanceCardList = value;
            }
        }

        public List<CommunityChestCard> CommunityChestCardList
        {
            get
            {
                return _communityChestCardList;
            }

            set
            {
                _communityChestCardList = value;
            }
        }

        public List<RailroadCard> RailroadCardList
        {
            get
            {
                return _railroadCardList;
            }

            set
            {
                _railroadCardList = value;
            }
        }

        public List<UtilityCard> UtilityCardList
        {
            get
            {
                return _utilityCardList;
            }

            set
            {
                _utilityCardList = value;
            }
        }

        #endregion
    }
}
