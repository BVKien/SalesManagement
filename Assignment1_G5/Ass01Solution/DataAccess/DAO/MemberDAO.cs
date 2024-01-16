using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class MemberDAO
    {
        // Using singleton Design Pattern 
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        public readonly eStoreContext dbContext = new eStoreContext();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public int GetMemberIdByEmail(string email)
        {
            Member member = dbContext.Members
                .FirstOrDefault(m => m.Email == email);

            if (member != null)
            {
                return member.MemberId;
            }

            // Handle the case where member is not found
            throw new InvalidOperationException("Member not found for the given email");
        }
    }
}
