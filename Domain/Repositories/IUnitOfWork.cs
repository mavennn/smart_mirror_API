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
        IRepository<Category> CategoryRepository { get; }
        IRepository<Image> ImageRepository { get; }
        IRepository<Size> SizeRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Consultant> ConsultantRepository { get; }
        IRepository<Request> RequestRepository { get; }
    }
}
