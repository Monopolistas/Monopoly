using System.Collections.Generic;

namespace Assets.Scripts.GameLogic.Entity
{
    public class BuildingType
    {
        public static readonly BuildingType House = new BuildingType(1, "HOUSE");
        public static readonly BuildingType Hotel = new BuildingType(2, "HOTEL");

        public BuildingType(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public static IEnumerable<BuildingType> Values
        {
            get
            {
                yield return House;
                yield return Hotel;
            }
        }

        public static BuildingType FindByCode(int code)
        {
            BuildingType type = null;
            foreach (BuildingType item in Values)
            {
                if (code.Equals(item.Code))
                {
                    type = item;
                }
            }
            return type;
        }

        public int Code { get; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var type = obj as BuildingType;
            return type != null &&
                   Code == type.Code;
        }

        public override int GetHashCode()
        {
            return -1021610220 + Code.GetHashCode();
        }

    }
}
