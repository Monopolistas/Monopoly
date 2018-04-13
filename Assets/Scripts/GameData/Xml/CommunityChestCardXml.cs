using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class CommunityChestCardXml
{
    static XmlDocument doc;
    static List<CommunityChestCard> communityChestCards;

    public static List<CommunityChestCard> Deserialize(string xml)
    {
        doc = new XmlDocument();
        doc.LoadXml(xml);
        XmlNode mainNode = doc.SelectSingleNode("community-chest-cards");
        XmlNodeList communityChestCardNodes = mainNode.SelectNodes("community-chest-card");
        communityChestCards = new List<CommunityChestCard>();

        foreach (XmlNode item in communityChestCardNodes)
        {
            CommunityChestCard ccc = new CommunityChestCard();

            string id = item.Attributes.GetNamedItem("id").Value;
            string text = item.ChildNodes.Item(0).InnerText;
            string value = item.ChildNodes.Item(1).InnerText;
            string transaction = item.ChildNodes.Item(2).InnerText;
            string cardAction = item.ChildNodes.Item(3).InnerText;
            string boardSlot = item.ChildNodes.Item(4).InnerText;
            string valuePerHouse = item.ChildNodes.Item(5).InnerText;
            string valuePerHotel = item.ChildNodes.Item(6).InnerText;

            ccc.Id = int.Parse(id);
            ccc.Text = text;
            ccc.Value = int.Parse(value);
            ccc.TransactionType = TransactionType.FindByCode(transaction);
            ccc.CardActionType = CardActionType.FindByCode(cardAction);
            ccc.BoardSlotId = int.Parse(id);
            ccc.ValuePerHouse = int.Parse(valuePerHouse);
            ccc.ValuePerHotel = int.Parse(valuePerHotel);
            ccc.CardType = CardType.COMMUNITY_CHEST;
            communityChestCards.Add(ccc);
        }

        return communityChestCards;
    }
}
