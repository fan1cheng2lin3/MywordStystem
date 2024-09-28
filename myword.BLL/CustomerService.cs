using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using myword.DAL;

namespace myword.BLL
{
    public class CustomerService
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public void Insert(string name, string password, string email)
        {
            user_Table customer = new user_Table
            {
                Name = name,
                Password = password,
                Email = email
            };
            db.user_Table.InsertOnSubmit(customer);
            db.SubmitChanges();
        }

        public bool IsNameExist(string name)
        {
            user_Table customer = (from c in db.user_Table
                                   where c.Name == name
                                   select c).FirstOrDefault();

            if (customer == null) {
                    return false;
            }
            else
            {
                return true;
            }
        }

        public int CheckLogin(string username, string password)
        {
            user_Table customer = (from c in db.user_Table
                                   where c.Name == username && c.Password == password
                                   select c).FirstOrDefault();

            if (customer != null) 
            {
                return customer.Userid;
            }
            else
            {
                return 0;
            }
        }

        public void Changepassword(int Userid, string password) 
        { 
            user_Table customer = ( from c in db.user_Table
                                    where c.Userid == Userid
                                    select c).First();

            customer.Password = password;

            db.SubmitChanges();
        }


        public bool IsEmailExist(string name, string email)
        {
            user_Table customer = (from c in db.user_Table
                                   where c.Name == name && c.Email == email
                                 select c).FirstOrDefault();
            if (customer != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void ResetPassword(string name, string email)
        {
            user_Table customer = (from c in db.user_Table
                                   where c.Name == name && c.Email == email
                                 select c).First();
            customer.Password = name;
            db.SubmitChanges();
        }


    }
}
