using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Interfaces;
using KCK_Project__Console_Pocket_trainer_.Models;
using System.Collections.Generic;
using System.Linq;

namespace KCK_Project__Console_Pocket_trainer_.Repositories
{
    public class DietRepository : IDietRepository
    {
        private readonly ApplicationDbContext _context;

        public DietRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Diet diet)
        {
            _context.Diets.Add(diet);
            return Save();
        }

        public bool Delete(Diet diet)
        {
            _context.Diets.Remove(diet);
            return Save();
        }

        public bool Update(Diet diet)
        {
            _context.Diets.Update(diet);
            return Save();
        }

        public Diet GetDietById(int id)
        {
            return _context.Diets.FirstOrDefault(d => d.Id == id);
        }

        public List<Diet> GetUserDiets(int userId)
        {
            return _context.Diets.Where(d => d.UserId == userId).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}

