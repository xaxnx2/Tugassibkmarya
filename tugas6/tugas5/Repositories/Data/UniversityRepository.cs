﻿using Tugas4.Context;
using Tugas4.Models;
using tugas5.Repositories.Interface;

namespace tugas5.Repositories.Data
{
    public class UniversityRepository : IUniversityRepository
    {

        private readonly MyContext _context;
        public UniversityRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<University> GetAll()
        {
            return _context.Set<University>().ToList();
        }

        public University? GetById(int id)
        {
            return _context.Set<University>().Find(id);
        }

        public int Insert(University university)
        {
            _context.Set<University>().Add(university);
            return _context.SaveChanges();
        }

        public int Update(University university)
        {
            _context.Set<University>().Update(university);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var university = GetById(id);
            if (university == null)
                return 0;

            _context.Set<University>().Remove(university);
            return _context.SaveChanges();
        }

    }
}
