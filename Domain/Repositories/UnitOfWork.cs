using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;
using SmartMirror.Domain.Models;

namespace SmartMirror.Domain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SmartMirrorDbContext _context;

        public IRepository<Product> ProductsRepository { get; }
        public IRepository<Size> SizeRepository { get; }
        public IRepository<Category> CategoriesRepository { get; }
        public IRepository<Image> ImagesRepository { get; }
        public IRepository<User> UsersRepository { get; }
        public IRepository<Basket> BasketRepository { get; set; }
        public IRepository<HistoryItem> HistoryRepository { get; set; }

        public UnitOfWork(SmartMirrorDbContext context)
        {
            _context = context;

            ProductsRepository = new ProductsRepository(_context);
            SizeRepository = new SizeRepository(_context);
            CategoriesRepository = new CategoriesRepository(_context);
            ImagesRepository = new ImagesRepository(_context);
            UsersRepository = new UserRepository(_context);
            BasketRepository = new BasketRepository(_context);
            HistoryRepository = new HistoryRepository(_context);
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
