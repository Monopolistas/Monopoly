namespace Assets.Scripts.GameLogic.Entity
{
    public class Building
    {
        public Building(BuildingType buildingType)
        {
            BuildingType = buildingType;
        }

        public BuildingType BuildingType { get; set; }

        public Lot Lot { get; set; }
    }
}
