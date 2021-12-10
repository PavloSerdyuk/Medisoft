using Hospital.Models;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Services
{
    public static class HospitalBuildingService
    {
        static List<HospitalBuilding> HospitalBuildings { get; }
        static int nextId = 3;
        static HospitalBuildingService()
        {
            HospitalBuildings = new List<HospitalBuilding>
            {
                new HospitalBuilding{id = 1},
                new HospitalBuilding{id = 2},
                new HospitalBuilding{id = 3}
            };
        }

        public static List<HospitalBuilding> GetAll() => HospitalBuildings;

        public static HospitalBuilding Get(int id) => HospitalBuildings.FirstOrDefault(p => p.id == id);

        public static void Add(HospitalBuilding hospitalBuilding)
        {
            hospitalBuilding.id = nextId++;
            HospitalBuildings.Add(hospitalBuilding);
        }

        

        public static void Delete(int id)
        {
            var hospitalBuilding = Get(id);
            if(hospitalBuilding is null)
                return;

            HospitalBuildings.Remove(hospitalBuilding);
        }

        public static void Update(HospitalBuilding hospitalBuilding)
        {
            var index = HospitalBuildings.FindIndex(p => p.id == hospitalBuilding.id);
            if(index == -1)
                return;

            HospitalBuildings[index] = hospitalBuilding;
        }
    }
}