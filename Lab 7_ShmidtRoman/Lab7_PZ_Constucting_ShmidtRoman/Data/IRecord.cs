namespace Lab7_PZ_Constucting_ShmidtRoman.Data
{
    public interface IRecord
    {
        List<Record> GetRecords();
        Record GetRecord(int id);
        void AddRecord(Record cus);
        void DeleteRecord(int id);
        Record EditRecord(Record customer);
    }
}
