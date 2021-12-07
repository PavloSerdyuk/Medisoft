using System;
using System.Collections.Generic;
using webApi7.Models;

namespace webApi7
{
   
    public interface IDecl
    {
        IEnumerable<Declaration> Get();
        Declaration Get(int id);
        void Create(Declaration d);
        void Update(Declaration d);
        Declaration Delete(int id);
    }

   
    public class DeclCRUD : IDecl
    {
        private kpz6Context Context;
        public IEnumerable<Declaration> Get()
        {
            return Context.Declaration;
        }
        public Declaration Get(int Id)
        {
            return Context.Declaration.Find(Id);
        }
        public DeclCRUD(kpz6Context context)
        {
            Context = context;
        }
        public void Create(Declaration item)
        {
            Context.Declaration.Add(item);
            Context.SaveChanges();
        }
        public void Update(Declaration updatedItem)
        {
            Declaration currentItem = Get(updatedItem.Id);
            currentItem.PatientId = updatedItem.PatientId;
            currentItem.DoctorId = updatedItem.DoctorId;
            currentItem.StartDate = updatedItem.StartDate;

            Context.Declaration.Update(currentItem);
            Context.SaveChanges();
        }

        public Declaration Delete(int Id)
        {
            Declaration item = Get(Id);

            if (item != null)
            {
                Context.Declaration.Remove(item);
                Context.SaveChanges();
            }

            return item;
        }
    }
}
