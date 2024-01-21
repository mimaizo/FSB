using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FSB.Data;
using System;
using System.Linq;
using fsb.Models;

namespace FSB.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FSBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FSBContext>>()))
            {
                // Look for any movies.
                if (context.Docs.Any())
                {
                    return;   // DB has been seeded
                }
                context.Docs.AddRange(
                    new Docs
                    {
                       FIO = "BOSHAKOV DANIIL ANDREEVICH", 
                       Title = "Паспорт",
                       Date = DateTime.Parse("01-12-2020"),
                       place = "МВД России",
                    },
                    new Docs
                    {
                        FIO = "SHAMRAY ALEXANDR DMITRIEVICH",
                        Title = "Паспорт",
                        Date = DateTime.Parse("25-10-2022"),
                        place = "МВД России",
                    },
                    new Docs
                    {
                        FIO = "IVANOV IVAN IVANOVICH",
                        Title = "Паспорт",
                        Date = DateTime.Parse("05-05-2020"),
                        place = "МВД России",
                    },
                    new Docs
                    {
                        FIO = "VASILEV KIRILL GEORGIEVICH",
                        Title = "Паспорт",
                        Date = DateTime.Parse("01-01-2001"),
                        place = "МВД России",
                    }
                );
                context.SaveChanges();
            }
        }
    }

}
