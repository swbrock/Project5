using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project5.Models
{
    public class MovieListContext : DbContext
    {
        public MovieListContext(DbContextOptions<MovieListContext> options) : base(options)
        {
            //Leave blank
        }

        //creates the table responses into the database
        public DbSet<MovieLists> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }
        //We need to seed these three movies into the database
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure"},
                new Category { CategoryId = 2, CategoryName = "Comedy"},
                new Category { CategoryId = 3, CategoryName = "Drama"},
                new Category { CategoryId = 4, CategoryName = "Family"},
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense"},
                new Category { CategoryId = 6, CategoryName = "Miscellaneous"},
                new Category { CategoryId = 7, CategoryName = "Television"},
                new Category { CategoryId = 8, CategoryName = "VHS"}
            );
            mb.Entity<MovieLists>().HasData(
                new MovieLists
                {
                    MovieId = 1,
                    CategoryId = 3,
                    Title = "A Walk to Remember",
                    Year = 2002,
                    Director = "Adam Shankman",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = "Get ready to cry"
                },
                new MovieLists
                {
                    MovieId = 2,
                    CategoryId = 1,
                    Title = "Spiderman: No Way Home",
                    Year = 2021,
                    Director = "Jon Watts",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieLists
                {
                    MovieId = 3,
                    CategoryId = 1,
                    Title = "Tenet",
                    Year = 2020,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Your mind might break"
                }
            );
        }
    }
}