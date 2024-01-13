using Microsoft.EntityFrameworkCore;
using RestfullDemo.Datas;
using RestfullDemo.Models;
using RestfullDemo.Repository.Interface;
using System.Collections.Generic;
using System.Data;

namespace RestfullDemo.Repository.Base
{
    public class BaseUserRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly DataBaseContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseUserRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public T Add(T model)
        {
            var resault = new T();

            _dbSet.Add(model);
            _dbContext.SaveChanges();
            resault = model;

            return resault;
        }

        public T Delete(T model)
        {
            //var resault = new T();
            //resault = model;
            _dbSet.Remove(model);
            _dbContext.SaveChanges();
            return model;

        }

        public void DeleteAll()
        {
            var allRecords = _dbSet.ToList();
            _dbSet.RemoveRange(allRecords);
            _dbContext.SaveChanges();
        }


        public List<T> GetAll()
        {
            var resault = new List<T>();
            var list = _dbSet.ToList();
            if (list != null)
                resault = list;
            else
                resault = null;

            return resault;
        }



        public T GetbyId(int id)
        {
            var result = _dbSet.FirstOrDefault(entity => EF.Property<int>(entity, "Id") == id);
            return result;
        }


        //public T UpdateById(T model, int id)
        //{
        //    var resault = new T();
        //    var mod = _dbSet.Find(id);
        //    if (mod == null)
        //        return null;
        //    //var response = _dbContext.Entry(mod);
        //    //response.State = EntityState.Modified;
        //    _dbContext.Entry(mod).CurrentValues.SetValues(model);
        //    _dbContext.SaveChanges();
        //    resault = mod;
        //    return resault;
        //}

        public T UpdateById(T model, int id)
        {
            var mod = _dbSet.Find(id);
            if (mod == null)
                return null;

            // UserRequestModel tipinde bir örnekse güncelleme yap
            if (mod is UserRequestModel userRequestModel && model is UserRequestModel incomingModel)
            {
                userRequestModel.UserName = incomingModel.UserName;
                userRequestModel.Password = incomingModel.Password;
                // Diğer özellikleri güncelleme ihtiyacınıza göre buraya ekleyin
            }

            _dbContext.SaveChanges();
            return mod;
        }


    }
}
