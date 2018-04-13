using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class UtilityCardXml : MonoBehaviour
{
    static XmlDocument doc;
    static List<UtilityCard> utilityCards;

    public static List<UtilityCard> Deserialize(string xml)
    {
        doc = new XmlDocument();
        doc.LoadXml(xml);
        XmlNode mainNode = doc.SelectSingleNode("utility-cards");
        XmlNodeList utilityCardNodes = mainNode.SelectNodes("utility-card");
        utilityCards = new List<UtilityCard>();

        foreach (XmlNode item in utilityCardNodes)
        {
            UtilityCard uc = new UtilityCard();

            string id = item.Attributes.GetNamedItem("id").Value;
            string name = item.ChildNodes.Item(0).InnerText;
            string price = item.ChildNodes.Item(1).InnerText;
            string rentWithOne = item.ChildNodes.Item(2).InnerText;
            string rentWithTwo = item.ChildNodes.Item(3).InnerText;
            string mortgage = item.ChildNodes.Item(4).InnerText;

            uc.Id = int.Parse(id);
            uc.Name = name;
            uc.Price = int.Parse(price);
            uc.MultiplierWithOne = int.Parse(rentWithOne);
            uc.MultiplierWithTwo = int.Parse(rentWithTwo);
            uc.Mortgage = int.Parse(mortgage);

            utilityCards.Add(uc);
        }

        return utilityCards;
    }
}
