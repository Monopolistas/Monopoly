using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.GameLogic.Entity;

namespace Assets.Scripts.GameData.Xml
{
    public class ChanceCardXml
    {
        private static XmlDocument _doc;
        private static List<ChanceCard> _chanceCards;

        public static List<ChanceCard> Deserialize(string xml)
        {
            _doc = new XmlDocument();
            _doc.LoadXml(xml);
            XmlNode mainNode = _doc.SelectSingleNode("chance-cards");
            if (mainNode != null)
            {
                XmlNodeList chanceCardNodes = mainNode.SelectNodes("chance-card");
                _chanceCards = new List<ChanceCard>();

                if (chanceCardNodes != null)
                {
                    foreach (XmlNode item in chanceCardNodes)
                    {
                        ChanceCard cc = new ChanceCard();

                        if (item.Attributes != null)
                        {
                            string id = item.Attributes.GetNamedItem("id").Value;
                            string text = item.ChildNodes.Item(0)?.InnerText;
                            string value = item.ChildNodes.Item(1)?.InnerText;
                            string transaction = item.ChildNodes.Item(2)?.InnerText;
                            string cardAction = item.ChildNodes.Item(3)?.InnerText;
                            string boardSlot = item.ChildNodes.Item(4)?.InnerText;
                            string multiplier = item.ChildNodes.Item(5)?.InnerText;
                            string boardSlotType = item.ChildNodes.Item(6)?.InnerText;
                            string valuePerHouse = item.ChildNodes.Item(7)?.InnerText;
                            string valuePerHotel = item.ChildNodes.Item(8)?.InnerText;

                            cc.Id = int.Parse(id);
                            cc.Text = text;
                            if (value != null)
                            {
                                cc.Value = int.Parse(value);
                            }

                            cc.TransactionType = TransactionType.FindByName(transaction);

                            cc.CardActionType = CardActionType.FindByCode(cardAction);
                            if (boardSlot != null)
                            {
                                cc.BoardSlotId = int.Parse(boardSlot);
                            }

                            if (multiplier != null)
                            {
                                cc.Multiplier = int.Parse(multiplier);
                            }

                            if (boardSlotType != null)
                            {
                                cc.BoardSlotType = BoardSlotType.FindByCode(int.Parse(boardSlotType));
                            }

                            if (valuePerHouse != null)
                            {
                                cc.ValuePerHouse = int.Parse(valuePerHouse);
                            }

                            if (valuePerHotel != null)
                            {
                                cc.ValuePerHotel = int.Parse(valuePerHotel);
                            }
                        }

                        cc.CardType = CardType.Chance;

                        _chanceCards.Add(cc);
                    }
                }
            }

            return _chanceCards;
        }
    }
}