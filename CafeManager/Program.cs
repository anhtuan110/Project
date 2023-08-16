namespace CafeManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new fLogin());
        }
    }
    //dotnet ef dbcontext scaffold "server =localhost; database = QuanLyQuanCafe;uid=sa;pwd=123456;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models
}