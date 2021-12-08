using EF_DAL.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IPersonnelService
    {
        void SetPerson(Person person);
        Person GetPersonById(int id);
        List<Person> GetPerson();
        Person DeletePerson(int id);
        Person UpdatePerson(int id, string name, string surname, string birthday);
    }
}
