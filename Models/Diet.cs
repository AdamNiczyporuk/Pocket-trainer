using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Models
{
    public class Diet
{
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
