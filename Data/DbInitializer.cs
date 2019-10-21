using LibraryManagement.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public static class DbInitializer
    {
        public static void Initial(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();
                //Customers
                var henry = new Customer { Name = "Henry Emma" };
                var chika = new Customer { Name = "Chika Wise" };
                var excel = new Customer { Name = "Excel Victor" };

                context.Customers.Add(henry);
                context.Customers.Add(chika);
                context.Customers.Add(excel);

                //Author
                var hassan = new Author
                {
                    Name = "Hassen A",
                    Books = new List<Book>()
                    {
                        new Book {Title = "Always Happy"},
                        new Book {Title = "Coming Home Soon"},
                        new Book {Title = "The Road is Short"}
                    }
                };

                var peter = new Author
                {
                    Name = "Peterson Obu",
                    Books = new List<Book>()
                    {
                        new Book {Title = "Doing good now"},
                        new Book {Title = "Remember our issue"},
                        new Book {Title = "Nature and it Home"},
                        new Book {Title = "The reason why we live"}
                    }
                };

                var nature = new Author
                {
                    Name = "Havard Nature",
                    Books = new List<Book>()
                    {
                        new Book {Title = "My Opinion"},
                        new Book {Title = "On earth"}
                    }
                };

                context.Authors.Add(hassan);
                context.Authors.Add(peter);
                context.Authors.Add(nature);

              
            }
        }
    }
}
