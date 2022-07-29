
using DataAccess.Concretes.EntityFramework;


using (AppDbContext context = new ())
{

    context.SaveChanges();
    Console.WriteLine("Kaydedildi.");
}