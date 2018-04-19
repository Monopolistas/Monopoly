using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.GameLogic.Entity;

namespace Assets.Scripts.GameData.Xml
{
    public class BoardSlotXml
    {
        private static XmlDocument _doc;
        private static List<BoardSlot> _boardSlots;

        public static List<BoardSlot> Deserialize(string xml)
        {
            _doc = new XmlDocument();
            _doc.LoadXml(xml);
            XmlNode mainNode = _doc.SelectSingleNode("board-slots");
            if (mainNode != null)
            {
                XmlNodeList boardSlotNodes = mainNode.SelectNodes("board-slot");
                _boardSlots = new List<BoardSlot>();

                if (boardSlotNodes != null)
                    foreach (XmlNode item in boardSlotNodes)
                    {
                        BoardSlot bs = new BoardSlot();

                        if (item.Attributes != null)
                        {
                            string id = item.Attributes.GetNamedItem("id").Value;
                            string boardSlotType = item.Attributes.GetNamedItem("boardSlotType").Value;
                            string lotId = item.Attributes.GetNamedItem("lotId").Value;

                            bs.Id = int.Parse(id);
                            bs.BoardSlotType = BoardSlotType.FindByCode(int.Parse(boardSlotType));
                            bs.LotId = int.Parse(lotId);
                        }

                        _boardSlots.Add(bs);
                    }
            }

            return _boardSlots;
        }
    }
}
