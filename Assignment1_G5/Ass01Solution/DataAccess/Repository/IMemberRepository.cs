using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        Member FindMember(string email, string password);
<<<<<<< HEAD
        int GetMemberIdByEmail(string email);
=======
        //Vuong Quoc Anh Code
        IEnumerable<Member> GetMembers();
        Member GetMemberByID(int memId);
        Member GetMemberByEmail(string email);
        void AddMember(Member member);
        void DeleteMember(Member member);
        void UpdateMember(Member member);
        //end Vuong Quoc Anh Code

>>>>>>> 2c1080b21fe3ba225999b06d9c437e8ade278825
    }
}
