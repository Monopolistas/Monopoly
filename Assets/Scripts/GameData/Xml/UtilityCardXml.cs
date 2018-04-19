using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.GameLogic.Entity;
using UnityEngine;

namespace Assets.Scripts.GameData.Xml
{
    public class UtilityCardXml : MonoBehaviour
    {
        private static XmlDocument _doc;
        private static List<UtilityCard> _utilityCards;

        public static List<UtilityCard> Deserialize(string xml)
        {
            _doc = new XmlDocument();
            _doc.LoadXml(xml);
            XmlNode mainNode = _doc.SelectSingleNode("utility-cards");
            if (mainNode != null)
            {
                XmlNodeList utilityCardNodes = mainNode.SelectNodes("utility-card");
                _utilityCards = new List<UtilityCard>();

                if (utilityCardNodes != null)
                    foreach (XmlNode item in utilityCardNodes)
                    {
                        UtilityCard uc = new UtilityCard();

                        if (item.Attributes != null)
                        {
                            string id = item.Attributes.GetNamedItem("id").Value;
                            string name = item.ChildNodes.Item(0)?.InnerText;
                            string price = item.ChildNodes.Item(1)?.InnerText;
                            string rentWithOne = item.ChildNodes.Item(2)?.InnerText;
                            string rentWithTwo = item.ChildNodes.Item(3)?.InnerText;
                            string mortgage = item.ChildNodes.Item(4)?.InnerText;

                            uc.Id = int.Parse(id);
                            uc.Name = name;
                            if (price != null) uc.Price = int.Parse(price);
                            if (rentWithOne != null) uc.MultiplierWithOne = int.Parse(rentWithOne);
                            if (rentWithTwo != null) uc.MultiplierWithTwo = int.Parse(rentWithTwo);
                            if (mortgage != null) uc.Mortgage = int.Parse(mortgage);
                        }

                        _utilityCards.Add(uc);
                    }
            }

            return _utilityCards;
        }
    }
}
