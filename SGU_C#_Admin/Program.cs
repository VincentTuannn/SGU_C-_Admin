using SGU_C__User.GUI;

namespace SGU_C__User
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
            Application.Run(new TrangChu_Admin()); // Thay TrangChu_Admin b?ng Login_Admin
        }
    }
}