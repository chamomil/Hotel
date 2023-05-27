using CommunityToolkit.Maui;
using Hotel.Application.Abstractions;
using Hotel.Application.Services;
using Hotel.Domain.Abstractions;
using Hotel.Domain.Entities;
using Hotel.Persistence.Data;
using Hotel.Persistence.Repository;
using Hotel.UI.Pages;
using Hotel.UI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Hotel.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string settingsStream = "Hotel.UI.appsettings.json";
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppInfo.Current.Name);

            if (!Path.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Preferences.Default.Set("LocalData", path);

            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);

            AddDbContext(builder);
            SetupServices(builder.Services);
            SetupViewModels(builder.Services);
            SetupPages(builder.Services);
            SeedData(builder.Services);

            return builder.Build();
        }

        public async static void SeedData(IServiceCollection services)
        {
            using var provider = services.BuildServiceProvider();
            var unitOfWork = provider.GetService<IUnitOfWork>();

            await unitOfWork.RemoveDatbaseAsync();
            await unitOfWork.CreateDatabaseAsync();

            IList<Room> rooms = new List<Room>() { };
            const int rooms_amount = 30;
            int rank = 1; // 1 - regular, 2 - comfy, 3 - lux
            int size = 1; // 1 - 1 bed, 2 - 2 people, 3 - 3 people

            for (int i = 0; i < rooms_amount; ++i)
            {
                if (size == 5)
                {
                    size = 1;
                }
                if (i >= 2 * rooms_amount / 3)
                {
                    rank = 3;
                }
                else if (i >= rooms_amount / 3)
                {
                    rank = 2;
                }

                rooms.Add(new Room() { Rank = rank, Size = size++, Number = i + 1});
            }

            foreach (Room room in rooms)
                await unitOfWork.RoomRepository.AddAsync(room);
            await unitOfWork.SaveAllAsync();

            IReadOnlyList<User> users = new List<User>()
            {
                new User() { Name = "Michael", Surname = "Stick",
                    DateOfBirth = new DateTime(1988, 12, 1), FathersName="tree",
                    Login="michst", Password = "stick999"},
                new User() { Name = "Maksim", Surname = "Konovaliuk",
                    DateOfBirth = new DateTime(1968, 9, 3),
                    Login="maksiksay", Password = "1111"},
                new User() { Name = "Maksim", Surname = "Konovaliuk",
                    DateOfBirth = new DateTime(1968, 9, 3),
                    Login="1", Password = "1"},
            };

            foreach (User user in users)
                await unitOfWork.UserRepository.AddAsync(user);
            await unitOfWork.SaveAllAsync();

            Random rand = new();
            int k = 1;
            foreach (User user in users)
            {
                await unitOfWork.BookingDataRepository.AddAsync(new BookingData()
                {
                    User = user,
                    Room = rooms[k++],
                    DateOfEntry = new DateTime(2023, 6, 6),
                    DateOfLeaving = new DateTime(2023, 6, 9),
                });
            }
            await unitOfWork.SaveAllAsync();
        }

        private static void AddDbContext(MauiAppBuilder builder)
        {
            var connStr = builder.Configuration.GetConnectionString("SqliteConnection");
            string dataDirectory = string.Empty;
#if ANDROID
            dataDirectory = FileSystem.AppDataDirectory + "/";
#endif
            connStr = string.Format(connStr, dataDirectory);
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connStr)
                .Options;
            builder.Services.AddSingleton((s) => new AppDbContext(options));
        }

        private static void SetupServices(IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IRoomService, RoomService>();
            services.AddSingleton<IBookingDataService, BookingDataService>();
        }

        private static void SetupViewModels(IServiceCollection services)
        {
            services.AddTransient<LogInViewModel>();
            services.AddTransient<SignUpViewModel>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<RoomDetailsViewModel>();
            services.AddTransient<MenuViewModel>();
        }

        private static void SetupPages(IServiceCollection services)
        {
            services.AddTransient<LogIn>();
            services.AddTransient<SignUp>();
            services.AddTransient<Home>();
            services.AddTransient<RoomDetails>();
            services.AddTransient<Menu>();
        }
    }
}