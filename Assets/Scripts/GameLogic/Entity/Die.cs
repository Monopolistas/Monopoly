using System;

namespace Assets.Scripts.GameLogic.Entity
{
    public class Die
    {
        private int _sides;

        public Die()
        {
            _sides = 6;
        }

        public void Throw()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());

            Result = (random.Next(_sides) + 1);
        }

        public int Result { get; set; }
    }
}
