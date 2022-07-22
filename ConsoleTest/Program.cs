
using DataAccess.Concretes.EntityFramework;
using Entities.Abstracts;
using Entities.Concretes;


using (AppDbContext context = new ())
{

    context.SaveChanges();
    Console.WriteLine("Kaydedildi.");
}