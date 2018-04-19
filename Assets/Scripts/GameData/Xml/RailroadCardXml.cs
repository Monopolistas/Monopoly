using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.GameLogic.Entity;

namespace Assets.Scripts.GameData.Xml
{
    public class RailroadCardXml
    {
        private static XmlDocument _doc;
        private static List<RailroadCard> _railroadCards;

        public static List<RailroadCard> Deserialize(string xml)
        {
            _doc = new XmlDocument();
            _doc.LoadXml(xml);
            XmlNode mainNode = _doc.SelectSingleNode("railroad-cards");
            if (mainNode != null)
            {
                XmlNodeList railroadCardNodes = mainNode.SelectNodes("railroad-card");
                _railroadCards = new List<RailroadCard>();

                if (railroadCardNodes != null)
                    foreach (XmlNode item in railroadCardNodes)
                    {
                        RailroadCard rc = new RailroadCard();

                        if (item.Attributes != null)
                        {
                            string id = item.Attributes.GetNamedItem("id").Value;
                            string name = item.ChildNodes.Item(0)?.InnerText;
                            string price = item.ChildNodes.Item(1)?.InnerText;
                            string rent = item.ChildNodes.Item(2)?.InnerText;
                            string rentWithTwo = item.ChildNodes.Item(3)?.InnerText;
                            string rentWithThree = item.ChildNodes.Item(4)?.InnerText;
                            string rentWithFour = item.ChildNodes.Item(5)?.InnerText;
                            string mortgage = item.ChildNodes.Item(6)?.InnerText;

                            rc.Id = int.Parse(id);
                            rc.Name = name;
                            if (price != null) rc.Price = int.Parse(price);
                            if (rent != null) rc.Rent = int.Parse(rent);
                            if (rentWithTwo != null) rc.TwoRailroadsRent = int.Parse(rentWithTwo);
                            if (rentWithThree != null) rc.ThreeRailroadsRent = int.Parse(rentWithThree);
                            if (rentWithFour != null) rc.FourRailroadsRent = int.Parse(rentWithFour);
                            if (mortgage != null) rc.Mortgage = int.Parse(mortgage);
                        }

                        rc.CardType = CardType.Railroad;

                        _railroadCards.Add(rc);
                    }
            }

            return _railroadCards;
        }
    }
}
