using SmartMirror.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMirror.Domain.Repositories
{
    public interface IUnitOfWork
    {
        void Commit();
        Task<int> CommitAsync();

        IRepository<Product> ProductsRepository { get; }
        IRepository<Size> SizeRepository { get; }
        IRepository<Category> CategoriesRepository { get; }
        IRepository<Image> ImagesRepository { get; }
        IRepository<User> UsersRepository { get; }
        IRepository<Basket> BasketRepository { get; set; }
        IRepository<HistoryItem> HistoryRepository { get; set; }
        IRepository<Consultant> ConsultantsRepository { get; set; }
        IRepository<Request> RequestRepository { get; set; }
        IRepository<RequestProduct>  RequestProductRepository { get; set; }
    }
}
