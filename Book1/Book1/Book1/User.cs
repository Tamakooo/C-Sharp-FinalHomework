using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book1
{
    public class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        public User()
        {
            UserId = Guid.NewGuid().ToString();
        }
        public User(string name,int code)
        {
            this.UserId = Guid.NewGuid().ToString();
            this.Name = name;
            this.Code = code;
        }
        public override bool Equals(object obj)
        {
            var customer = obj as User;
            return customer != null &&UserId == customer.UserId &&Name == customer.Name;
        }

    }
}
