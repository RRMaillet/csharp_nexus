namespace api_controller.Models.Repositories
{
    public static class FloorRepository
    {
        private static List<Floor> floors = new List<Floor>()
        {
            new Floor{ FloorId= 12, FloorName="Laminate", FloorColor="Beige", FloorDescription="Beige Laminate Floor", Price=1.53},
            new Floor{ FloorId= 15, FloorName="Cork", FloorColor="Brown", FloorDescription="Brown Cork Floor", Price=2.10},
            new Floor{ FloorId= 18, FloorName="Leather", FloorColor="Black", FloorDescription="Black Leather Floor", Price=4.53},
            new Floor{ FloorId= 19, FloorName="Wood", FloorColor="Green", FloorDescription="Green Wood Floor", Price=2.99},
            new Floor{ FloorId= 21, FloorName="Polycarbonate", FloorColor="Clear", FloorDescription="Clear Polycarbonate Floor", Price=0.95}
        };


        public static bool FloorExists(int id)
        {
            return floors.Any(x => x.FloorId == id);
        }

        public static Floor? GetFloorById(int id)
        {
            return floors.FirstOrDefault(x => x.FloorId == id);
        }

    }
}
