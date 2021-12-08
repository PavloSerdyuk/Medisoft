using BLL.Interfaces;
using EF_DAL.Entities;
using EF_DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Implementation
{
    public class PersonnelService : IPersonnelService
    {
        private readonly IUnitOfWork<Person> unitOfWork;
        
        public PersonnelService(
            IUnitOfWork<Person> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void SetPerson(Person person)
        {
            unitOfWork.GetRepository().Add(person);
            unitOfWork.SaveChanges();
        }

        public Person GetPersonById(int id)
        {
            return unitOfWork.GetRepository()
            .Query()
            .Where(person => person.Person_id == id).FirstOrDefault();
        }

        public List<Person> GetPerson()
        {
            return unitOfWork.GetRepository()
            .Query().ToList();
        }

        public Person DeletePerson(int id)
        {
            try
            {
                Person userToDelete = unitOfWork.GetRepository().Query().Where(person => person.Person_id == id).FirstOrDefault();
                unitOfWork.GetRepository().Delete(userToDelete);
                unitOfWork.SaveChanges();
                return userToDelete;
            }
            catch
            {
                return null;
            }

        }
        
        public Person UpdatePerson(int id, string name, string surname, string birthday)
        {
            try
            {
                Person personToUpdate = unitOfWork.GetRepository()
                                    .Query()
                                    .Where(person => person.Person_id == id).FirstOrDefault();
                personToUpdate.Name = name;
                personToUpdate.Surname = surname;
                personToUpdate.Birthday = birthday;
                unitOfWork.GetRepository().Update(personToUpdate);
                unitOfWork.SaveChanges();
                return personToUpdate;
            }
            catch
            {
                return null;
            }

        }
    }
}
