using DataAccess.DAO;
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
        public readonly MemberDAO memberDAO;
        public Member FindMember(string email, string password)
        {
            try
            {
                using var context = new eStoreContext();
                return context.Members
                    .FirstOrDefault(m => m.Email == email && m.Password == password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
<<<<<<< HEAD

        public int GetMemberIdByEmail(string email) => MemberDAO.Instance.GetMemberIdByEmail(email);
=======
        //Vuong Quoc Anh Code
        public void AddMember(Member member)
        => MemberDAO.Instance.AddNew(member);

        public void DeleteMember(Member member)
        => MemberDAO.Instance.Remove(member);

        public Member GetMemberByID(int memId)
        => MemberDAO.Instance.GetMemberByID(memId);

        public IEnumerable<Member> GetMembers()
        => MemberDAO.Instance.GetMembersList();

        public void UpdateMember(Member member)
        => MemberDAO.Instance.Update(member);

        public Member GetMemberByEmail(string email)
        => MemberDAO.Instance.GetMemberByEmail(email);
        //End Vuong Quoc Anh Code
>>>>>>> 2c1080b21fe3ba225999b06d9c437e8ade278825
    }
}
