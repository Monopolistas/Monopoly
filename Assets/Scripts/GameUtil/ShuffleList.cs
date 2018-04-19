using System;
using System.Collections.Generic;

namespace Assets.Scripts.GameUtil
{
    public class ShuffleList<T>
    {
        public static List<T> Shuffle(List<T> list)
        {
            // Sattolo's algorithm for shuffle
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = list.Count; i-- > 1;)
            {
                int j = random.Next(i);
                var tmp = list[i];
                list[i] = list[j];
                list[j] = tmp;
            }
            return list;
        }
    }
}
