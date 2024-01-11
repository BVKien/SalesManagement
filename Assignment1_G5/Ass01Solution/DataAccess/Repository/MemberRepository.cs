using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public Member FindMember(string email, string password)
        {
            try
            {
                using var context = new eStoreContext();
                return context.Members
                    .FirstOrDefault(m => m.Email == email && m.Password == password);
            } 
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
