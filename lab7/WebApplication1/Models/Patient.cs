using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Patient
    {
        private int id;
        private string firstName;
        private string lastName;
        private string dateOfBirth;
        private int depId;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
            }
        }
        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
            }
        }
        public int DepId
        {
            get { return depId; }
            set
            {
                depId = value;
            }
        }
    }
}
