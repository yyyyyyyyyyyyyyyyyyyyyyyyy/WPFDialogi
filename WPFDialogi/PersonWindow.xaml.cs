using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFDialogi
{
    public partial class PersonWindow : Window
    {
        public Person person;

        public PersonWindow()
        {
            InitializeComponent();
            education.ItemsSource = Enum.GetValues(typeof(EducationLevel)).Cast<EducationLevel>();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
