using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.DAL.DAO
{
    public class BaseDAO<T> : IDAO<T> where T : class
    {
        public BarbeariaContext _context { get; set; }

        public BaseDAO()
        {
            _context = new BarbeariaContext();
        }
        public virtual T Get(long id)
        {

            var obj = _context.Set<T>().Find(id);
            if (obj == null)
            {
                throw new OperationCanceledException("Could not find any with the given Id");
            }
            return obj;

        }



        public virtual T Create(T obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

            return obj;

        }
        public virtual T Update(T obj)
        {
            using (_context = new BarbeariaContext())
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();

                return obj;
            }

        }
        public virtual void Delete(T obj)
        {
            using (_context = new BarbeariaContext())
            {
                if (obj != null)
                {
                    _context.Remove(obj);
                    _context.SaveChanges();
                }
            }

        }
        public virtual void Delete(long id)
        {
            using (_context = new BarbeariaContext())
            {
                var obj = Get(id);

                if (obj != null)
                {
                    _context.Remove(obj);
                    _context.SaveChanges();
                }
            }
        }
        public virtual IEnumerable<T> GetAll()
        {
            var _context = new BarbeariaContext();
            return _context.Set<T>();

        }

        public object Get(string v)
        {
            var obj = _context.Set<T>().Find(v);
            if (obj == null)
            {
                throw new OperationCanceledException("Could not find any with the given Id");
            }
            return obj;
        }
    }
}
