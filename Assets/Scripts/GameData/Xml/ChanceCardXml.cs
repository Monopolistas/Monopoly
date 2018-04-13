using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ChanceCardXml
{
    static XmlDocument doc;
    static List<ChanceCard> chanceCards;

    public static List<ChanceCard> Deserialize(string xml)
    {
        doc = new XmlDocument();
        doc.LoadXml(xml);
        XmlNode mainNode = doc.SelectSingleNode("chance-cards");
        XmlNodeList chanceCardNodes = mainNode.SelectNodes("chance-card");
        chanceCards = new List<ChanceCard>();

        foreach (XmlNode item in chanceCardNodes)
        {
            ChanceCard cc = new ChanceCard();

            string id = item.Attributes.GetNamedItem("id").Value;
            string text = item.ChildNodes.Item(0).InnerText;
            string value = item.ChildNodes.Item(1).InnerText;
            string transaction = item.ChildNodes.Item(2).InnerText;
            string cardAction = item.ChildNodes.Item(3).InnerText;
            string boardSlot = item.ChildNodes.Item(4).InnerText;
            string multiplier = item.ChildNodes.Item(5).InnerText;
            string boardSlotType = item.ChildNodes.Item(6).InnerText;
            string valuePerHouse = item.ChildNodes.Item(7).InnerText;
            string valuePerHotel = item.ChildNodes.Item(8).InnerText;

            cc.Id = int.Parse(id);
            cc.Text = text;
            cc.Value = int.Parse(value);
            cc.TransactionType = TransactionType.FindByCode(transaction);
            cc.CardActionType = CardActionType.FindByCode(cardAction);
            cc.BoardSlotId = int.Parse(boardSlot);
            cc.Multiplier = int.Parse(multiplier);
            cc.BoardSlotType = BoardSlotType.FindByCode(int.Parse(boardSlotType));
            cc.ValuePerHouse = int.Parse(valuePerHouse);
            cc.ValuePerHotel = int.Parse(valuePerHotel);
            cc.CardType = CardType.CHANCE;

            chanceCards.Add(cc);
        }

        return chanceCards;
    }
}