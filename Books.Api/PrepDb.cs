using Books.DataBase.SqlServer;
using Books.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.Api
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<BookDbContext>());
            }
        }

        private static void SeedData(BookDbContext context)
        {
            context.Database.Migrate();

            if (!context.PublishingHouses.Any())
            {
                Console.WriteLine("--> Seeding Publishing Houses Data");
                context.PublishingHouses.AddRange(
                    new PublishingHouse() 
                    { 
                        Name = "Texto Editores Ltda.",
                        Authors = {
                            new Author()
                            {
                                AuthorName = "George R.R. Martins",
                                Books = {
                                    new Book()
                                    {
                                        Title = "A danca dos dragoes"
                                    },
                                    new Book()
                                    {
                                        Title = "O Festim dos corvos"
                                    },
                                    new Book()
                                    {
                                        Title = "A tormenta das espadas"
                                    }
                                }
                            }
                        }
                    },
                    new PublishingHouse()
                    {
                        Name = "Editora Record",
                        Authors = {
                            new Author()
                            {
                                AuthorName = "Conn Iggulden",
                                Books =
                                {
                                    new Book()
                                    {
                                        Title = "O Conquistador: O lobo nas planicies"
                                    },
                                    new Book()
                                    {
                                        Title = "Os Senhores do Arco"
                                    },
                                    new Book()
                                    {
                                        Title = "Os ossos das colinas"
                                    }
                                }
                            },
                            new Author()
                            {
                                AuthorName = "Bernard Cornwell",
                                Books =
                                {
                                    new Book()
                                    {
                                        Title = "O Ultimo Reino"
                                    },
                                    new Book()
                                    {
                                        Title = "O Cavaleiro da Morte"
                                    }
                                }
                            }
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
