using Microsoft.EntityFrameworkCore;

namespace Lab7_PZ_Constucting_ShmidtRoman.Data
{
    public class SqlDoctor : IDoctor
    {
        HospitalCodeContext hospitalCodeContext;
        public SqlDoctor(HospitalCodeContext ctx)
        {
            hospitalCodeContext = ctx;
        }

        public void AddDoctor(Doctor cus)
        {
            hospitalCodeContext.Doctors.Add(cus);
            hospitalCodeContext.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            hospitalCodeContext.Remove(hospitalCodeContext.Doctors.FirstOrDefault(x => x.Id == id));
            hospitalCodeContext.SaveChanges();
        }

        public Doctor EditDoctor(Doctor customer)
        {
            Doctor cus = hospitalCodeContext.Doctors.FirstOrDefault(x => x.Id == customer.Id);
            cus = customer;
            hospitalCodeContext.SaveChanges();
            return cus;
        }

        public Doctor GetDoctor(int id)
        {
            return hospitalCodeContext.Doctors.SingleOrDefault(x => x.Id == id);
        }

        public List<Doctor> GetDoctors()
        {
            return hospitalCodeContext.Doctors.ToList();
        }
    }
}
