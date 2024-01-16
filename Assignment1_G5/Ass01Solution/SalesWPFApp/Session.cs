using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWPFApp
{
    public class Session
    {
        public static Member memberSession;

        public Session()
        {
        }

        public static void LogoutUser()
        {
            memberSession = null;
        }
    }
}
