namespace Assets.Scripts.GameLogic.Entity
{
    public class Card
    {
        public int Id { get; set; }

        public CardType CardType { get; set; }

        public Player Owner { get; set; }
    }
}
