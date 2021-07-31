using System;
using System.Collections.Generic;
using System.Text;
using Magazin.Services.Users;
using MagazinData;
using MagazinData.Users;
using Omu.ValueInjecter;
namespace Magazin.Services.General1
{
    public class Login : ILogin
    {
        private int Instance = 0;
        private readonly IRepository<User> _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserServices userServices;
        public Login(IRepository<User> repo, IUnitOfWork unitOfWork, IUserServices userServices)
        {
            this.userServices = userServices;
            _repo = repo;
            _unitOfWork = unitOfWork;
        }
        public User Authentification(string username, string password)
        {
            Instance++;
            var user = _repo.GetByName(username);
            if (user == null)
                return null;
            
            if (user.Password == password)
            {              
                return user;
            }
            return null;

        }
        public User Getuser(string username)
        {
            var user = _repo.GetByName(username);
            return user;
        }
        public bool Instancy()
        {
            if (Instance < 3)
                return true;
            else
                return false;

        }
        public void UpdateProfile(User user)
        {
            var _user = userServices.GetUserById(user.UserName);
            _user.InjectFrom(user);
            var User = new User();
            User.InjectFrom(_user);
            _repo.Update(User);
            _unitOfWork.Commit();

        }
    }
}
