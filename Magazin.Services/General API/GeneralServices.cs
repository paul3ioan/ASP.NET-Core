using System;
using MagazinData;
using MagazinData.Users;
using System.Collections.Generic;
using System.Text;
using MagazinData.Entity;
using Omu.ValueInjecter;
using System.Linq;
using Magazin.Services.Product;
using Microsoft.WindowsAzure.Storage.Blob.Protocol;

namespace Magazin.Services.General1
{
    public class GeneralServices : IGeneralServices
        
    {
        
        private static List<Aliment> alimente;
        private static List<Jucarii> jucarii;
        private static List<Books> books;
        private readonly IRepository<Produs> _repoProdus;
        private readonly IRepository<ProductDetailsDto> _repoShow;
        private readonly IRepository<Jucarii> _repoJucarii;
        private readonly IRepository<Aliment> _repoAliment;
        private readonly IRepository<Books> _repoBooks;
        private readonly IUnitOfWork _unitOfWork;
       
        
        public GeneralServices(IRepository<Jucarii> jucarie,IRepository<Produs> produs,
            IRepository<Aliment> aliment, IRepository<Transaction> repository,
            IRepository<Books> book, IUnitOfWork unitOfWork,
            IRepository<ProductDetailsDto>repoShow)
        {
            
            _repoProdus = produs;
            _repoShow = repoShow;
            //_repoTransaction = repository;
            _repoAliment = aliment;
            _repoBooks = book;
            _repoJucarii = jucarie;
            _unitOfWork = unitOfWork;
        }
      public int GetProductBySame(Produs produs, enumtype type)
        {
             var product= new List<Produs>();
             product = _repoProdus.Query(
                            x => x.Name == produs.Name &&
                            x.Price == produs.Price &&
                            x.RegistrationDate == produs.RegistrationDate &&
                            x.UserId == produs.UserId &&
                            x.RegistrationNumber == produs.RegistrationNumber &&
                            x.Typee == produs.Typee
                        ).ToList();
            return product[0].ProductID;
        

    }

        public void Update(ProductDto list)
        {
            var produs = new Produs();
            produs.InjectFrom(list);
                _repoProdus.Update(produs);
            
            _unitOfWork.Commit();
        }
        public Aliment GetAliment(int ProductId)
        {
            
            var aliment = _repoAliment.Query(x => x.ProdusId == ProductId).ToList();            
            return aliment[0];
        }

        public Jucarii GetJucarie(int ProductId)
        {
            var jucarie = _repoJucarii.Query(x => x.ProductId == ProductId).ToList();
            return jucarie[0];
        }

        public Books GetBook(int ProductId)
        {
            var books = _repoBooks.Query(x => x.ProdusId == ProductId).ToList();
            return books[0];
        }

        public void AddJucarie(Jucarii jucarii)
        {
         //   var toys = _repoJucarii.Query(x => x.ProductId == id).ToList();
           // jucarii.ProductId = toys
            _repoJucarii.Add(jucarii);
            _unitOfWork.Commit();
        }

        public void AddBooks(Books books)
        {
            _repoBooks.Add(books);
            _unitOfWork.Commit();
        }

        public void AddAliment(Aliment aliment)
        {
            _repoAliment.Add(aliment);
            _unitOfWork.Commit();
            
        }
        public Tip GetTip(enumtype type, int ProductID )
        {
            return type switch
            {
                enumtype.aliment => _repoAliment.GetById(ProductID),
                enumtype.jucarii => _repoJucarii.GetById(ProductID),
                enumtype.books => _repoBooks.GetById(ProductID),
                _=> throw new NotImplementedException(),
            };
        }
    }
}
