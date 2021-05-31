using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics_Averkin.Business
{
    class UserPassword
    {
        public UserPassword(string Name, string Password)
        {
            this.Name = Name;
            this.Password = Password;
        }

        public string Name { get; set; }
        public string Password { get; set; }
    }
}
