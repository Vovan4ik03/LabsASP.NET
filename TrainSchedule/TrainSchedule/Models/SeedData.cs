//using Microsoft.EntityFrameworkCore;

//namespace TrainSchedule.Models
//{
//    public class SeedData
//    {
//        public static void EnsurePopulated(IApplicationBuilder app)
//        {
//            TrainScheduleDbContext context = app.ApplicationServices
//                .CreateScope().ServiceProvider
//                .GetRequiredService<TrainScheduleDbContext>();

//            if (context.Database.GetPendingMigrations().Any())
//            {
//                //context.Database.Migrate();
//            }

//                  if (!context.Platforms.Any())
//            {
//                context.Platforms.AddRange(
//                    new Platform
//                    {
//                        PlatformNumber = 1,
//                        StationName = "Житомир",
//                    },
//                    new Platform
//                    {
//                        PlatformNumber = 2,
//                        StationName = "Київ",
//                    },
//                    new Platform
//                    {
//                        PlatformNumber = 3,
//                        StationName = "Львів",
//                    },
//                    new Platform
//                    {
//                        PlatformNumber = 4,
//                        StationName = "Одеса",
//                    }
//                );
//                context.SaveChanges();
//            }

            
//            var platform1 = context.Platforms.First(p => p.PlatformNumber == 1);
//            var platform2 = context.Platforms.First(p => p.PlatformNumber == 2);
//            var platform3 = context.Platforms.First(p => p.PlatformNumber == 3);
//            var platform4 = context.Platforms.First(p => p.PlatformNumber == 4);

            
//            if (!context.Trains.Any())
//            {
//                context.Trains.AddRange(
//                    new Trains
//                    {
//                        TrainName = "Житомир — Львів",
//                        TrainType = "Швидкісний",
//                        TrainNumber = "120",
//                        PlatformId = platform1.Id
//                    },
//                    new Trains
//                    {
//                        TrainName = "Нічний Експрес",
//                        TrainType = "Пасажирський",
//                        TrainNumber = "45",
//                        PlatformId = platform2.Id
//                    },
//                    new Trains
//                    {
//                        TrainName = "Карпати",
//                        TrainType = "Швидкий",
//                        TrainNumber = "82",
//                        PlatformId = platform3.Id
//                    },
//                    new Trains
//                    {
//                        TrainName = "Поділля",
//                        TrainType = "Пасажирський",
//                        TrainNumber = "97",
//                        PlatformId = platform1.Id
//                    },
//                    new Trains
//                    {
//                        TrainName = "Слобожанщина",
//                        TrainType = "Швидкий",
//                        TrainNumber = "63",
//                        PlatformId = platform4.Id
//                    },
//                    new Trains
//                    {
//                        TrainName = "Чорноморець",
//                        TrainType = "Нічний",
//                        TrainNumber = "108",
//                        PlatformId = platform4.Id
//                    },
//                    new Trains
//                    {
//                        TrainName = "Київ — Львів",
//                        TrainType = "Інтерсіті+",
//                        TrainNumber = "350",
//                        PlatformId = platform2.Id
//                    },
//                    new Trains
//                    {
//                        TrainName = "Одеса — Харків",
//                        TrainType = "Пасажирський",
//                        TrainNumber = "89",
//                        PlatformId = platform4.Id
//                    },
//                    new Trains
//                    {
//                        TrainName = "Прикарпаття",
//                        TrainType = "Швидкий",
//                        TrainNumber = "50",
//                        PlatformId = platform3.Id
//                    },
//                    new Trains
//                    {
//                        TrainName = "Донбас Експрес",
//                        TrainType = "Швидкісний",
//                        TrainNumber = "120A",
//                        PlatformId = platform2.Id
//                    }
//                );

//                context.SaveChanges();
//            }
//        }
//    }
//}

