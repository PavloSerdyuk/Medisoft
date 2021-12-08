namespace EF_DAL.Entities
{
    public class Person : IEntity
    {
        public int Person_id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
    }
}
