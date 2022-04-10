﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManage : IUserService
    {
        private IUserDal _userdal;

        public UserManage(IUserDal userdal)
        {
            _userdal = userdal;
        }

        public void Add(User user)
        {
            _userdal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userdal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userdal.GetClaims(user);
        }
    }
}
