using System;
using System.ServiceProcess;
using System.Windows;

namespace DataManager.WorkWithWindowService
{
    public class ConnectionWithWindowService
    {
        private static string service = "Lr4 Win Service";

        private static ServiceController serv = new ServiceController(service);

        public void StartService()
        {
            if (serv.Status != ServiceControllerStatus.Running)
            {
                serv.Start();
                serv.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMinutes(1));
                MessageBox.Show("Succes","Start",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Already loaded","Start",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        public void StopService()
        {
            if (serv.Status != ServiceControllerStatus.Stopped)
            {
                serv.Stop();
                serv.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                MessageBox.Show("Stopped succesfully","Stop",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Already stopped","Stop",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        private void ShowMessage(string eventDescription, string serviceEvent)
        {
            MessageBox.Show($"The service {eventDescription}", $"{serviceEvent}");

        }
    }
}
