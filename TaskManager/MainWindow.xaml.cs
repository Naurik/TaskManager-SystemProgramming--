using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using TaskManagerModels;

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            gridTaskManager.IsReadOnly = true;
            ShowTaskManager();
        }

        public void ShowTaskManager()
        {
            Process[] procList = Process.GetProcesses();
            List<TaskManagersClass> taskManagers = new List<TaskManagersClass>();
                for(int i=0; i<procList.Count(); i++)
                {
                    taskManagers.Add(new TaskManagersClass {Name=procList[i].ProcessName + ".exe", Id = procList[i].Id, Memory = procList[i].PagedSystemMemorySize,
                                    Status= "Отказано в доступе", Description = "Отказано в доступе",
                        Processor = "Отказано в доступе", UsersName="Отказано в доступе"/*(UserName - отказано в доступе или MashineName только)*/});
                }
            gridTaskManager.ItemsSource = taskManagers;
        }

        private void ButtonTaskManagerClick(object sender, RoutedEventArgs e)
        {
            Process[] procList = Process.GetProcesses();
            if(gridTaskManager.SelectedItem != null)
            {
                int index = gridTaskManager.SelectedIndex;
                try
                {

                    procList[index].Kill();
                }
                catch(Exception)
                {
                    MessageBox.Show("Отказано в доступе");
                }
            }
        }
    }
}
