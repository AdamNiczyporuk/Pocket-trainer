using KCK_Project__Console_Pocket_trainer_.Interfaces;
using KCK_Project__Console_Pocket_trainer_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>();

        public bool Add(User user)
        {
            users.Add(user);
            return true;
        }

        public bool Delete(User user)
        {
            return users.Remove(user);
        }

        public User GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByUserName(string userName)
        {
            return users.FirstOrDefault(u => u.UserName == userName);
        }

        public bool Save()
        {
            // Implementacja zapisu do bazy danych lub innego źródła danych
            return true;
        }

        public bool Update(Exercise user)
        {
           return true;
        }
    }
}
