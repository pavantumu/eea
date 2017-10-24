﻿using AutoMapper;
using EEAFormI9Portal.EF;
using EEAFormI9Portal.Factory.IServices;
using EEAFormI9Portal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEAFormI9Portal.Factory.IServicesImplementation
{
    public class UserManagement : IUserManagement
    {
        private readonly EEAFORMI9Entities db = new EEAFORMI9Entities();

        public bool DeleteUser(string Id)
        {
            try
            {
                var u = db.AspNetUsers.Single(x => x.Id == Id);
                if (u != null)
                {
                    db.AspNetUsers.Remove(u);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                var x = ex.ToString();
            }
            return false;
            
        }

        public ViewUserDetails GetUserById(string Id)
        {
            var u = db.AspNetUsers.SingleOrDefault(x => x.Id == Id);
            var user = new ViewUserDetails();
            if(u != null)
            {
                user = new ViewUserDetails
                {
                    Id = u.Id,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    UserName = u.UserName
                };
            }

            return user;
        }

        public List<AspNetUser> GetUserDetails()
        {
            return db.AspNetUsers.ToList();
        }

        public List<ViewUserAndRoleDetails> GetUserAndRoleDetails()
        {
            var User = new ViewUserAndRoleDetails();
            var userFromDb = db.AspNetUsers.ToList();

            var e = Mapper.Map<List<ViewUserAndRoleDetails>>(userFromDb);

            return e;
        }

        public ViewUserDetails UpdateUserDetails(ViewUserDetails user)
        {
            ViewUserDetails update = Mapper.Map<ViewUserDetails>(user);

            try
            {
                var oldUser = db.AspNetUsers.Single(x => x.Id == user.Id);
                oldUser.Email = user.Email;
                oldUser.PhoneNumber = user.PhoneNumber;
                oldUser.UserName = user.UserName;

                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var x = dbEx.ToString();
            }
            catch (Exception ex)
            {
                var x = ex.ToString();
            }
            return Mapper.Map<ViewUserDetails>(user);
        }

        public List<Representative> GetRepresentativeDetails()
        {
            return db.Representatives.ToList();
        }

        public Representative AddRepresentative(Representative rep)
        {
            //var update = db.Representatives.Find(rep.Id);
            
                try
                {
                    db.Representatives.Add(rep);
                    db.SaveChanges();
                    return rep;
                }
                catch (Exception ex)
                {
                    return null;
                }
            
        }

        public bool ConfirmAccount(object data)
        {
            var user = db.AspNetUsers.Single();

            throw new NotImplementedException();
        }
    }
}
