using KCK_Project__Console_Pocket_trainer_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Interfaces
{
    public interface IDietRepository
{
        bool Add(Diet diet);
        bool Delete(Diet diet);
        bool Update(Diet diet);
        bool Save();
        Diet GetDietById(int id);
        List<Diet> GetUserDiets(int userId);
    }
}
