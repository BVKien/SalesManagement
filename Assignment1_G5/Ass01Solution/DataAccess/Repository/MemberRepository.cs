using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository, IDisposable
    {
        private eStoreContext _eStoreContext;

        public MemberRepository()
        {
            this._eStoreContext = new eStoreContext();
        }

        public int CreateMember(Member member)
        {
            _eStoreContext.Members.Add(member);
            return _eStoreContext.SaveChanges();
        }

        public int DeleteMember(int id)
        {
            //var myStockDB = new eStoreContext();
            _eStoreContext.Members.Remove(GetMember(id));
            return _eStoreContext.SaveChanges();
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose Active");
            _eStoreContext.Dispose();
        }

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

        public List<Member> GetAll()
        {
            List<Member> list = new List<Member>();
            try
            {

                list = _eStoreContext.Set<Member>().ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Member GetMember(int id)
        {

            var member = _eStoreContext.Members.SingleOrDefault(m => m.MemberId == id);
            return member;

        }

        public int UpdateMember(Member member)
        {
            _eStoreContext.Entry(member).State = EntityState.Modified;
            return _eStoreContext.SaveChanges();
        }
    }
}
