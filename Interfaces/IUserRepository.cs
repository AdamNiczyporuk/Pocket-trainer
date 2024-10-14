using KCK_Project__Console_Pocket_trainer_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Interfaces
{
    public interface IUserRepository
{
        bool Add(User user);
        bool Delete(User user);
        bool Update(Exercise user);
        User GetUserByUserName(string userName);
        User GetUserById(int id);
        bool Save();
    }
}
