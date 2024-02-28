using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDialogi
{
    internal class ListOfPersons
    {
        public ObservableCollection<Person> persons;
        public ListOfPersons()
        {
            persons = new ObservableCollection<Person>();
            LoadPersons("plik.txt");
        }
        public void AddPerson(Person person)
        {
            persons.Add(person);
        }
        public void RemovePerson(Person person)
        {
            persons.Remove(person);
        }
        public void EditPerson(int index, Person person)
        {
            persons[index] = person;
        }
        public void RemovePersonAt(int index)
        {
            if (index >= 0 && index < persons.Count)
                persons.RemoveAt(index);
        }
        public void LoadPersons(string file)
        {
            //tu należy zrobić pobieranie z pliku zamiast poniższego kodu
            persons.Clear();
            persons.Add(new Person("Adam", "Kowalski", EducationLevel.średnie));
            persons.Add(new Person("Monika", "Dudek", EducationLevel.podstawowe));
            persons.Add(new Person("Jan", "Sobieski", EducationLevel.wyższe));
            persons.Add(new Person("Marta", "Nowak", EducationLevel.średnie));
        }
        public void SavePersons(string file)
        {
            //tu zapis do pliku
        }
    }
}
