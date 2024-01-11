using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace BusinessObject.Objects
{
    public class MemberObject
    {
        private readonly IMemberRepository memberRepository;

        public MemberObject()
        {
            memberRepository = new MemberRepository();
        }

        public bool Login(string email, string password)
        {
            if (memberRepository.FindMember(email, password) == null)
            {
                return false;
            }
            return true;
        }
    }
}
