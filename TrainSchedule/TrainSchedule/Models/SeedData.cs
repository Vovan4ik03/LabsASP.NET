using Microsoft.EntityFrameworkCore;

namespace TrainSchedule.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            TrainScheduleDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<TrainScheduleDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Trains.Any())
            {
                context.Trains.AddRange(
                new Trains
                {
                   TrainName = "Житомир-Львів",
                   TrainType = "Швидкісний",
                   TrainNumber = "120"
                },
                new Trains
                {
                    TrainName = "Нічний Експрес",
                    TrainType = "Пасажирський",
                    TrainNumber = "45"
                },
                new Trains
                {
                  TrainName = "Карпати",
                  TrainType = "Швидкий",
                  TrainNumber = "82"
                },
                new Trains
                {
                  TrainName = "Поділля",
                  TrainType = "Пасажирський",
                  TrainNumber = "97"
                },
                new Trains
                {
                    TrainName = "Слобожанщина",
                    TrainType = "Швидкий",
                    TrainNumber = "63"
                },
                new Trains
                {
                  TrainName = "Чорноморець",
                  TrainType = "Нічний",
                  TrainNumber = "108"
                },
                new Trains
                {
                    TrainName = "Київ — Львів",
                    TrainType = "Інтерсіті+",
                    TrainNumber = "350"
                },
                new Trains
                {
                    TrainName = "Одеса — Харків",
                    TrainType = "Пасажирський",
                    TrainNumber = "89"
                },
                new Trains
                {
                 TrainName = "Прикарпаття",
                 TrainType = "Швидкий",
                 TrainNumber = "50"
                },
                new Trains
                {
                 TrainName = "Донбас Експрес",
                 TrainType = "Швидкісний",
                 TrainNumber = "120"
                });
                context.SaveChanges();
            }
        }

    }
}
