using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (kpz6Context db = new kpz6Context())
            {
                Declaration decl = new Declaration();
                decl.Id = 1;
                decl.PatientId = 5;
                decl.DoctorId = 8;
                decl.StartDate = DateTime.Parse("2021/05/04 15:00");
                db.Declaration.Add(decl);
                db.SaveChanges();
                decl.Id = 2;
                decl.PatientId = 9;
                decl.DoctorId = 8;
                decl.StartDate = DateTime.Parse("2021/08/04 15:00");
                
                db.Declaration.Add(decl);
                db.SaveChanges();
            }
        }
    }
}
