using Lr4Win;
using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using DataManager.WorkWithWindowService;
using Serv;
using ConfigurationManager;
using DataAccessLayer;
using System.Threading;
using LoggerToDB;

namespace DataManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConnectionToDataBase connectToBase;
        private ConfigurationProvider provide;
        private RelocateOfFiles fileRelocate;
        private List<OptionsForDeserealizing> list = new List<OptionsForDeserealizing>();

        private Json jsFile = new Json();
        private XML xmlFile = new XML();
        private ErrorLogger errorLogs = new ErrorLogger();

        private ConnectionWithWindowService connectToService;
        

        public MainWindow()
        {
            InitializeComponent();
            connectToBase = new ConnectionToDataBase();
            provide = new ConfigurationProvider();
            list = provide.GetOption();
            connectToService = new ConnectionWithWindowService();

            fileRelocate = new RelocateOfFiles();

            sourceText.Text = list[0].source;
            archiveText.Text = list[0].target;
            extractText.Text = list[0].extract;
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                connectToBase.ConnectAndInteract();
                MessageBox.Show("Подключение установлено, связь стабильная", "Подключение", MessageBoxButton.OK, MessageBoxImage.Question);
            }
            catch (Exception ex)
            {
                errorLogs.WriteErrorsToDataBase(ex.Message);
                MessageBox.Show(ex.Message, "Подключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void dbSet_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(connectToBase.GetDataBaseInfo(), "Информация о состоянии базы", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void disconnectButton_Click(object sender, RoutedEventArgs e)
        {
            connectToBase.Disconnect();
            MessageBox.Show("Подключение разорвано", "Подключение", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void startMonitorButton_Click(object sender, RoutedEventArgs e)
        {
            FolderWatcher sourceWatcher = new FolderWatcher(sourceText.Text);
            FolderWatcher archiveWatcher = new FolderWatcher(archiveText.Text);
            FolderWatcher extractWatcher = new FolderWatcher(extractText.Text);
            sourceWatcher.StartWatching();
            archiveWatcher.StartWatching();
            extractWatcher.StartWatching();
            connectToService.StartService();
        }
          
        private void stopMonitorButton_Click(object sender, RoutedEventArgs e)
        {
            connectToService.StopService();
        }

        private void createConfigButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                jsFile.Gen();
                xmlFile.Gen();
                MessageBox.Show("Файлы конфигурации созданы успешно", "Создание файлов конфигурации", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                errorLogs.WriteErrorsToDataBase(ex.Message);
                MessageBox.Show(ex.Message, "Создание файлов конфигурации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void removeConfigButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                fileRelocate.Relocate();
                Thread.Sleep(1000);
                MessageBox.Show("Файлы конфигурции перенесены успешно", "Перенос файлов конфигурации", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                errorLogs.WriteErrorsToDataBase(ex.Message);
                MessageBox.Show(ex.Message, "Перенос файлов конфигурации", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
