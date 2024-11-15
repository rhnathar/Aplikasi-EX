using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_EX.Model
{
    public static class UserSession
    {
        private static User _currentUser;

        public static User CurrentUser
        {
            get => _currentUser;
            set => _currentUser = value;
        }

        public static bool IsUserLoggedIn => _currentUser != null;
    }
}
