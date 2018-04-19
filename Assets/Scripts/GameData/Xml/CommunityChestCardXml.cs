using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.GameLogic.Entity;

namespace Assets.Scripts.GameData.Xml
{
    public class CommunityChestCardXml
    {
        private static XmlDocument _doc;
        private static List<CommunityChestCard> _communityChestCards;

        public static List<CommunityChestCard> Deserialize(string xml)
        {
            _doc = new XmlDocument();
            _doc.LoadXml(xml);
            XmlNode mainNode = _doc.SelectSingleNode("community-chest-cards");
            if (mainNode != null)
            {
                XmlNodeList communityChestCardNodes = mainNode.SelectNodes("community-chest-card");
                _communityChestCards = new List<CommunityChestCard>();

                if (communityChestCardNodes != null)
                {
                    foreach (XmlNode item in communityChestCardNodes)
                    {
                        CommunityChestCard ccc = new CommunityChestCard();

                        if (item.Attributes != null)
                        {
                            string id = item.Attributes.GetNamedItem("id").Value;
                            string text = item.ChildNodes.Item(0)?.InnerText;
                            string value = item.ChildNodes.Item(1)?.InnerText;
                            string transaction = item.ChildNodes.Item(2)?.InnerText;
                            string cardAction = item.ChildNodes.Item(3)?.InnerText;
                            string boardSlot = item.ChildNodes.Item(4)?.InnerText;
                            string valuePerHouse = item.ChildNodes.Item(5)?.InnerText;
                            string valuePerHotel = item.ChildNodes.Item(6)?.InnerText;

                            ccc.Id = int.Parse(id);
                            ccc.Text = text;
                            if (value != null)
                            {
                                ccc.Value = int.Parse(value);
                            }

                            if (transaction != null)
                            {
                                ccc.TransactionType = TransactionType.FindByCode(int.Parse(transaction));
                            }

                            ccc.CardActionType = CardActionType.FindByCode(cardAction);
                            if (boardSlot != null)
                            {
                                ccc.BoardSlotId = int.Parse(boardSlot);
                            }

                            if (valuePerHouse != null)
                            {
                                ccc.ValuePerHouse = int.Parse(valuePerHouse);
                            }

                            if (valuePerHotel != null)
                            {
                                ccc.ValuePerHotel = int.Parse(valuePerHotel);
                            }
                        }

                        ccc.CardType = CardType.CommunityChest;
                        _communityChestCards.Add(ccc);
                    }
                }
            }

            return _communityChestCards;
        }
    }
}
