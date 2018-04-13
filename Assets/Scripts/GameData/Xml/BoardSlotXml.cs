using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class BoardSlotXml
{
    static XmlDocument doc;
    static List<BoardSlot> boardSlots;

    public static List<BoardSlot> Deserialize(string xml)
    {
        doc = new XmlDocument();
        doc.LoadXml(xml);
        XmlNode mainNode = doc.SelectSingleNode("board-slots");
        XmlNodeList boardSlotNodes = mainNode.SelectNodes("board-slot");
        boardSlots = new List<BoardSlot>();

        foreach (XmlNode item in boardSlotNodes)
        {
            BoardSlot bs = new BoardSlot();

            string id = item.Attributes.GetNamedItem("id").Value;
            string boardSlotType = item.Attributes.GetNamedItem("boardSlotType").Value;
            string lotId = item.Attributes.GetNamedItem("lotId").Value;

            bs.Id = int.Parse(id);
            bs.BoardSlotType = BoardSlotType.FindByCode(int.Parse(boardSlotType));
            bs.LotId = int.Parse(lotId);

            boardSlots.Add(bs);
        }

        return boardSlots;
    }
}
