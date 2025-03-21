﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories {
    public class GenericRepository<T> : IGenericDal<T> where T : class {
        
        public void Delete(T t) {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetById(int id) {
            using var c = new Context();
            return c.Set<T>().Find(id);
        }

        public List<T> GetList() {
            using var c = new Context();
            return c.Set<T>().ToList();
        }


        public void Insert(T t) {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t) {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }
    }
}
