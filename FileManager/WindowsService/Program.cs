using System.ServiceProcess;

namespace Lr4Win
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main()
        {
#if DEBUG
            Service1 serv = new Service1();
            serv.OnDebug();
#else
            ServiceBase[] ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
