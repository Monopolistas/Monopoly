using System.Collections.Generic;

namespace Assets.Scripts.GameLogic.Entity
{
    public class PersonType
    {
        public static readonly PersonType Player = new PersonType(1, "PLAYER");
        public static readonly PersonType Bank = new PersonType(2, "BANK");

        public PersonType(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public static IEnumerable<PersonType> Values
        {
            get
            {
                yield return Player;
                yield return Bank;
            }
        }

        public static PersonType FindByCode(string code)
        {
            PersonType type = null;
            foreach (PersonType item in Values)
            {
                if (code.Equals(item.Code))
                {
                    type = item;
                }
            }
            return type;
        }

        public int Code { get; set; }

        public string Name { get; set; }
    }
}
