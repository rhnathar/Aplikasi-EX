using Aplikasi_EX.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_EX.Utilities
{
    public class AccountUpdatedMessage
    {
        public User UpdatedUser { get; }
        public AccountUpdatedMessage(User updatedUser)
        {
            UpdatedUser = updatedUser;
        }
    }
}
