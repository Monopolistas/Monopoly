using System.Collections.Generic;

namespace Assets.Scripts.GameLogic.Entity
{
    public class DiceThrow
    {
        private List<Die> _dieList;

        public DiceThrow()
        {
            Reset();
        }

        public void Reset()
        {
            _dieList = new List<Die>();
            _dieList.Add(new Die());
            _dieList.Add(new Die());
            Result = new List<int>();
            Result.Add(0);
            Result.Add(0);
            IsThrown = false;
        }

        public void Throw()
        {
            for (int i = 0; i < _dieList.Count; i++)
            {
                _dieList[i].Throw();
                Result[i] = _dieList[i].Result;
            }
            IsThrown = true;
        }

        public bool IsDouble()
        {
            if (IsThrown)
                return Result[0].Equals(Result[1]);
            return false;
        }

        public int Sum
        {
            get
            {
                return Result[0] + Result[1];
            }
        }

        public List<int> Result { get; set; }

        public bool IsThrown { get; set; }
    }
}
