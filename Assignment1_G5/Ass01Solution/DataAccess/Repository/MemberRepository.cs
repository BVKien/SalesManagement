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
    }
}
