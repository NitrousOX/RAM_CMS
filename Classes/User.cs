using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum User_Role {ADMIN, VISITOR}

namespace RAM_CMS.Classes
{
    [Serializable]
    public class User
    {
        private string name;
        private string password;
        private string theme;
        private User_Role type;

        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        internal User_Role Type { get => type; set => type = value; }
        public string Theme { get => theme; set => theme = value; }

        public User(string name, string password, User_Role type, string theme)
        {
            this.name = name;
            this.password = password;
            this.type = type;
            this.theme = theme;

        }

        public User()
        {
        }
    }
}
