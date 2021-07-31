using System;
using System.Collections.Generic;
using System.Text;
using MagazinData.Users;
using MagazinData;
using System.Linq;
using Magazin.Services.Users;
using Omu.ValueInjecter;
using MagazinData.Entity;
using Magazin.Services.Product;

namespace Magazin.Services.Users.TypeOfUsers
{
    public class Manager : IManager
    {
        private readonly IRepository<Produs> _repoProdus;
        private readonly IRepository<Transaction> _repoTrans;
        private readonly IRepository<User> _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserServices _userServices;
        public Manager(IRepository<Produs> produs,IRepository<Transaction> repoTrans, IRepository<User> repo,IUserServices us,IUnitOfWork unitOfWork)
        {
            _repoProdus = produs;
            _repoTrans = repoTrans;
            _repo = repo;
            _unitOfWork = unitOfWork;
            _userServices = us;
        }
        public void ChangeProfile(string name)
        {
            _userServices.ChangeInfo(name);
        }
        public int SeeProfit()
        {
            var data = DateTime.Now.AddDays(-3);
            int profit = 0;
            var transactions = _repoTrans.Query(x => x.data >= data).ToList();
            foreach(var item in transactions)
            {
                if (item.Valid == enumvalid.NStoc)
                    profit += item.Price;
                else
                    profit -= item.Price;
            }
            return profit;
        }
        public List<Transaction> SeeEmployActivity(string userName)
        {
            var activity = _repoTrans.Query(x => x.UserId== userName).ToList();
            var list = activity.OrderByDescending(x => x.data);
            var lastDay = DateTime.Now.AddDays(-7);
            var employActivity = new List<Transaction>();
            foreach(var transaction in list)
            {
                if (transaction.data < lastDay)
                    break;
                employActivity.Add(transaction);
            }
            return employActivity;
        }
        public IList<UserDto> AllEmployer()
        {
            var allEmployer = _userServices.GetAllEmployers();
            return allEmployer;
        }
        public void RemoveUser(string Name)
        {
            var user = _repo.GetByName(Name);
            if (user == null)
                throw new ArgumentNullException();
            if (user.Rank == rank.manager)
                throw new ArgumentException();
            _repo.Delete(user);
            _unitOfWork.Commit();
        }
        public void AddEmployer(User user)
        {
         //   var user =_userServices.CreateUser();
           _userServices.AddUser(user, rank.manager);
           _unitOfWork.Commit();
        }
        public void ChangePrice(string name, int price)
        {
            var product = _repoProdus.Query(x => x.Name == name).ToList();
            
            if (product.Count == 0)
            {
                Console.WriteLine($"The product doesn't exist no changes were made");
                return;
            }
            foreach (var item in product)
            {
                item.Price += price;
                if (item.Price <= 0)
                    item.Price -= price;
                _repoProdus.Update(item);
            }
            Console.WriteLine($"Changes were made");
            _unitOfWork.Commit();        
        }
        
    }
}
