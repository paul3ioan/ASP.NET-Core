using System;
using MagazinData;
using System.Collections.Generic;
using System.Text;
using MagazinData.Entity;
using System.Linq;
using Magazin.Services.Product;
namespace Magazin.Services.General
{
    public class GeneralServices : IGeneralServices
    {

        private readonly IRepository<Jucarii> _repoJucarii;
        private readonly IRepository<Aliment> _repoAliment;
        private readonly IRepository<Books> _repoBooks;
        public GeneralServices(IRepository<Jucarii> jucarie,
            IRepository<Aliment> aliment,
            IRepository<Books> book)
        {
            _repoAliment = aliment;
            _repoBooks = book;
            _repoJucarii = jucarie;
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
