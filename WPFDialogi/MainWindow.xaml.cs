using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WPFDialogi
{
    public partial class MainWindow : Window
    {
        ListOfPersons pList = new ListOfPersons();

        public MainWindow()
        {
            InitializeComponent();
            pListView.ItemsSource = pList.persons;
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            PersonWindow personWindow = new PersonWindow();
            personWindow.person = new Person();
            personWindow.DataContext = personWindow.person;
            var result = personWindow.ShowDialog();
            if (result == true)
            {
                pList.AddPerson(personWindow.person);
            }
        }

        private void EditPerson_Click(object sender, RoutedEventArgs e)
        {
            PersonWindow personWindow = new PersonWindow();
            Person per = pList.persons[pListView.SelectedIndex];
            personWindow.person = new Person(per.FirstName, per.LastName, per.Education);
            personWindow.DataContext = personWindow.person;
            var result = personWindow.ShowDialog();
            if (result == true)
            {
                pList.EditPerson(pListView.SelectedIndex, personWindow.person);
            }
        }
        private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {
            pList.RemovePersonAt(pListView.SelectedIndex);
        }

        private void Sort(string sortBy)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(pListView.ItemsSource);
            dataView.SortDescriptions.Clear();
            dataView.SortDescriptions.Add(new SortDescription(sortBy, ListSortDirection.Ascending));
            dataView.Refresh();
        }

        private void SortByName_Click(object sender, RoutedEventArgs e)
        {
            Sort("FirstName");
        }

        private void SortByLastName_Click(object sender, RoutedEventArgs e)
        {
            Sort("LastName");
        }

        private void SortByEducation_Click(object sender, RoutedEventArgs e)
        {
            Sort("Education");
        }
    }
}
