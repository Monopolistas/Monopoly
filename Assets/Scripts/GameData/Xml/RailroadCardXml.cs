using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class RailroadCardXml
{
    static XmlDocument doc;
    static List<RailroadCard> railroadCards;

    public static List<RailroadCard> Deserialize(string xml)
    {
        doc = new XmlDocument();
        doc.LoadXml(xml);
        XmlNode mainNode = doc.SelectSingleNode("railroad-cards");
        XmlNodeList railroadCardNodes = mainNode.SelectNodes("railroad-card");
        railroadCards = new List<RailroadCard>();

        foreach (XmlNode item in railroadCardNodes)
        {
            RailroadCard rc = new RailroadCard();

            string id = item.Attributes.GetNamedItem("id").Value;
            string name = item.ChildNodes.Item(0).InnerText;
            string price = item.ChildNodes.Item(1).InnerText;
            string rent = item.ChildNodes.Item(2).InnerText;
            string rentWithTwo = item.ChildNodes.Item(3).InnerText;
            string rentWithThree = item.ChildNodes.Item(4).InnerText;
            string rentWithFour = item.ChildNodes.Item(5).InnerText;
            string mortgage = item.ChildNodes.Item(6).InnerText;

            rc.Id = int.Parse(id);
            rc.Name = name;
            rc.Price = int.Parse(price);
            rc.Rent = int.Parse(rent);
            rc.TwoRailroadsRent = int.Parse(rentWithTwo);
            rc.ThreeRailroadsRent = int.Parse(rentWithThree);
            rc.FourRailroadsRent = int.Parse(rentWithFour);
            rc.Mortgage = int.Parse(mortgage);
            rc.CardType = CardType.RAILROAD;

            railroadCards.Add(rc);
        }

        return railroadCards;
    }
}
