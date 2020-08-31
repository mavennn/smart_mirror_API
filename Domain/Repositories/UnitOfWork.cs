using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using SmartMirror.Domain.Models;

namespace SmartMirror.Domain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SmartMirrorDbContext _context;

        public IRepository<Product> ProductsRepository { get; }
        public IRepository<Size> SizeRepository { get; }
        public IRepository<Category> CategoryRepository { get; }
        public IRepository<Image> ImageRepository { get; }
        public IRepository<User> UserRepository { get; }
        public IRepository<Consultant> ConsultantRepository { get; }
        public IRepository<Request> RequestRepository { get; }

        public UnitOfWork(SmartMirrorDbContext context)
        {
            _context = context;

            ProductsRepository = new ProductsRepository(_context);
            SizeRepository = new SizeRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            ImageRepository = new ImageRepository(_context);
            UserRepository = new UserRepository(_context);
            ConsultantRepository = new ConsultantRepository(_context);
            RequestRepository = new RequestRepository(_context);
        }

    
        public void Commit()
        {
            _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }


    }
}
