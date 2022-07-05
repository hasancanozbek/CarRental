
using DataAccess.Concretes.EntityFramework;
using Entities.Abstracts;
using Entities.Concretes;

Customer customer = new Customer() { Email = "hasancanozbekk@gmail.com",Password="12345",
    FirstName="Hasan Can", LastName ="Özbek",NationalId ="11111111111", Telephone = "5446540580",Address="Bostanbaşı/Yeşilyurt/Malatya"};

using (AppDbContext context = new ())
{
    context.Customers.Add(customer);
    context.SaveChanges();
    Console.WriteLine("Kaydedildi.");
}