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
        int GetMemberIdByEmail(string email);
        //Vuong Quoc Anh Code
        IEnumerable<Member> GetMembers();
        Member GetMemberByID(int memId);
        Member GetMemberByEmail(string email);
        void AddMember(Member member);
        void DeleteMember(Member member);
        //void UpdateMember(Member member);
        //end Vuong Quoc Anh Code

        /// <summary>
        /// get all member with admin
        /// </summary>
        /// <returns> list of member in database</returns>
        /// @author: gitzno - thuyht
        /// @date: 14/01/2024
        public List<Member> GetAll();
        /// <summary>
        /// get a member with id 
        /// </summary>
        /// <param name="id">id of member</param>
        /// <returns>member have id like id input</returns>
        /// @author: gitzno - thuyht
        /// @date: 14/01/2024
        public Member GetMember(int id);
        /// <summary>
        /// update a member with id
        /// </summary>
        /// <param name="member">member with id and entity want update</param>
        /// <returns>number of status </returns>
        /// @author: gitzno - thuyht
        /// @date: 14/01/2024
        public void UpdateMember(Member member);
        /// <summary>
        /// delete a member with id
        /// </summary>
        /// <param name="id">id of member</param>
        /// <returns>number status command</returns>
        /// @author: gitzno - thuyht
        /// @date: 14/01/2024
        public int DeleteMember(int id);
        /// <summary>
        /// create member
        /// </summary>
        /// <param name="member">member want create</param>
        /// <returns>number status of command</returns>
        /// @author: gitzno - thuyht
        /// @date: 14/01/2024
        public int CreateMember(Member member);
    }
}
