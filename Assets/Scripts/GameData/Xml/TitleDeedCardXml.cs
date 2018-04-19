using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.GameLogic.Entity;

namespace Assets.Scripts.GameData.Xml
{
    public class TitleDeedCardXml
    {
        private static XmlDocument _doc;
        private static List<TitleDeedCard> _titleDeedCards;

        public static List<TitleDeedCard> Deserialize(string xml)
        {
            _doc = new XmlDocument();
            _doc.LoadXml(xml);
            XmlNode mainNode = _doc.SelectSingleNode("title-deed-cards");
            if (mainNode != null)
            {
                XmlNodeList titleDeedCardNodes = mainNode.SelectNodes("title-deed-card");
                _titleDeedCards = new List<TitleDeedCard>();

                if (titleDeedCardNodes != null)
                    foreach (XmlNode item in titleDeedCardNodes)
                    {
                        TitleDeedCard tdc = new TitleDeedCard();

                        if (item.Attributes != null)
                        {
                            string id = item.Attributes.GetNamedItem("id").Value;
                            string name = item.ChildNodes.Item(0)?.InnerText;
                            string price = item.ChildNodes.Item(1)?.InnerText;
                            string rent = item.ChildNodes.Item(2)?.InnerText;
                            string rentOneHouse = item.ChildNodes.Item(3)?.InnerText;
                            string rentTwoHouses = item.ChildNodes.Item(4)?.InnerText;
                            string rentThreeHouses = item.ChildNodes.Item(5)?.InnerText;
                            string rentFourHouses = item.ChildNodes.Item(6)?.InnerText;
                            string rentHotel = item.ChildNodes.Item(7)?.InnerText;
                            string mortgage = item.ChildNodes.Item(8)?.InnerText;
                            string buildingPrice = item.ChildNodes.Item(9)?.InnerText;
                            string groupColor = item.ChildNodes.Item(10)?.InnerText;

                            tdc.Id = int.Parse(id);
                            tdc.Name = name;
                            tdc.Price = int.Parse(price);
                            tdc.Rent = int.Parse(rent);
                            tdc.OneHouseRent = int.Parse(rentOneHouse);
                            tdc.TwoHousesRent = int.Parse(rentTwoHouses);
                            tdc.ThreeHousesRent = int.Parse(rentThreeHouses);
                            tdc.FourHousesRent = int.Parse(rentFourHouses);
                            tdc.HotelRent = int.Parse(rentHotel);
                            tdc.Mortgage = int.Parse(mortgage);
                            tdc.BuildingPrice = int.Parse(buildingPrice);
                            tdc.GroupColor = GroupColor.FindByName(groupColor);
                        }

                        tdc.CardType = CardType.TitleDeed;

                        _titleDeedCards.Add(tdc);
                    }
            }

            return _titleDeedCards;
        }
    }
}
