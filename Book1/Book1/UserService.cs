using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Book1
{
    public class UserService
    {

        public List<User> Users
        {
            get
            {
                using (var context = new BookContext())
                {
                    return context.Users
                      .ToList<User>();
                }
            }
        }

        public void AddUser(User user)
        {
            using (var context = new BookContext())
            {
                context.Entry(user).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public User GetUser(string id)
        {
            using (var context = new BookContext())
            {
                return context.Users
                  .SingleOrDefault(o => o.UserId == id);
            }
        }

        public User GetUser2(string name)
        {
            using (var context = new BookContext())
            {
                return context.Users
                  .SingleOrDefault(o => o.Name == name);
            }
        }
    }
}
