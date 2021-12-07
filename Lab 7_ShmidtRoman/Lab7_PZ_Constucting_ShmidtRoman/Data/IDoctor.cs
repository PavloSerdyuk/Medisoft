namespace Lab7_PZ_Constucting_ShmidtRoman.Data
{
    public interface IDoctor
    {
        List<Doctor> GetDoctors();
        Doctor GetDoctor(int id);
        void AddDoctor(Doctor cus);
        void DeleteDoctor(int id);
        Doctor EditDoctor(Doctor customer);
    }
}
