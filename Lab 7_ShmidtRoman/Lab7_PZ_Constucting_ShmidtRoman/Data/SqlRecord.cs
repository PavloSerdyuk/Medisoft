namespace Lab7_PZ_Constucting_ShmidtRoman.Data
{
    public class SqlRecord : IRecord
    {
        HospitalCodeContext hospitalCodeContext;
        public SqlRecord(HospitalCodeContext ctx)
        {
            hospitalCodeContext = ctx;
        }

        public void AddRecord(Record cus)
        {
            hospitalCodeContext.Records.Add(cus);
            hospitalCodeContext.SaveChanges();
        }

        public void DeleteRecord(int id)
        {
            hospitalCodeContext.Remove(hospitalCodeContext.Records.FirstOrDefault(x => x.Id == id));
            hospitalCodeContext.SaveChanges();
        }

        public Record EditRecord(Record customer)
        {
            Record cus = hospitalCodeContext.Records.FirstOrDefault(x => x.Id == customer.Id);
            cus = customer;
            hospitalCodeContext.SaveChanges();
            return cus;
        }

        public Record GetRecord(int id)
        {
            return hospitalCodeContext.Records.SingleOrDefault(x => x.Id == id);
        }

        public List<Record> GetRecords()
        {
            return hospitalCodeContext.Records.ToList();
        }
    }
}
