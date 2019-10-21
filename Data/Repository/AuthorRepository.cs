using LibraryManagement.Data.Interfaces;
using LibraryManagement.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context) : base(context)
        {

        }

        public IEnumerable<Author> GetAllAndBooks()
        {
            return _context.Authors.Include(a => a.Books);
        }

        public Author GetwithBooks(int id)
        {
            return _context.Authors.Where(a => a.AuthorId == id)
                .Include(a => a.Books).FirstOrDefault();
        }
    }
}
