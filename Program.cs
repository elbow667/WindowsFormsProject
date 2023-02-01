using Microsoft.Extensions.Configuration;

// using IConfiguration to access appsettings.json and get various parameters and settings
// such as connection string to database, form settings and such.

namespace WinFormsApp2
{
    static class Program
    {
        public static IConfiguration? Configuration;
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();


            Application.Run(new Form1());
        }



    }
}