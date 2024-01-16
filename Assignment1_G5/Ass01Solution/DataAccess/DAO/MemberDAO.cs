using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class MemberDAO
    {
        // Singleton Design Pattern 
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
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
        //Vuong Quoc Anh Code
        public IEnumerable<Member> GetMembersList()
        {
            List<Member> members;
            try
            {
                var estoreDB = new eStoreContext();
                members = estoreDB.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }
        //-----------------------
        public Member GetMemberByID(int memId)
        {
            Member member = null;
            try
            {
                var estoreDB = new eStoreContext();
                member = estoreDB.Members.SingleOrDefault(m => m.MemberId == memId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        //---------------------
        public Member GetMemberByEmail(string email)
        {
            Member member = null;
            try
            {
                var estoreDB = new eStoreContext();
                member = estoreDB.Members.SingleOrDefault(m => m.Email.Trim().Equals(email.Trim()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        //-----------------
        public void AddNew(Member member)
        {
            try
            {
                Member _member = GetMemberByID(member.MemberId);
                if (_member == null)
                {
                    var eStoreDB = new eStoreContext();
                    eStoreDB.Members.Add(member);
                    eStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("Member exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //---------------------
        public void Update(Member member)
        {
            /*  try
              {
                  Member m = GetMemberByID(member.MemberId);
                  if (m != null)
                  {
                      var estoreDB = new eStoreContext();
                      estoreDB.Entry<Member>(member).State = EntityState.Modified;
                      estoreDB.SaveChanges();
                  }
                  else
                  {
                      throw new Exception("Member not exist.");
                  }
              }catch(Exception ex)
              {
                  throw new Exception(ex.Message);
              }*/
            try
            {
                using (var estoreDB = new eStoreContext())
                {
                    //Member m = GetMemberByEmail(member.Email);
                    Member m = estoreDB.Members.FirstOrDefault(x => x.MemberId == member.MemberId);
                    if (m != null)
                    {
                        m.Email = member.Email;
                        m.CompanyName = member.CompanyName;
                        m.City = member.City;
                        m.Password = member.Password;
                        m.Country = member.Country;
                        //estoreDB.Entry<Member>(member).State = EntityState.Modified;
                        estoreDB.SaveChanges();


                    }
                    else
                    {
                        throw new Exception("Member not exist.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //--------------------------

        public void Remove(Member member)
        {
            try
            {
                Member _member = GetMemberByID(member.MemberId);
                if (_member != null)
                {
                    var estoreDB = new eStoreContext();
                    estoreDB.Members.Remove(member);
                    estoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("Member not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //end Vuong Quoc Anh Code
    }
}
