// 2020-12-25, Bruce

using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComFram
{
    public class PersonViewModel : Conductor<object>
    {
        private BindableCollection<PersonModel> _persons = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson = new PersonModel();
        private string _search_name;

        public BindableCollection<PersonModel> Persons
        {
            get { return _persons; }
            set { _persons = value; }
        }

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                //_selectedPerson = value;
                if (value != null)
                {
                    _selectedPerson.CopyFrom(value);
                    NotifyOfPropertyChange(() => SelectedPerson);
                }
            }
        }

        public string SearchName
        {
            get { return _search_name; }
            set
            {
                _search_name = value;
                NotifyOfPropertyChange(() => SearchName);
            }
        }


        /// <summary>
        /// 构造
        /// </summary>
        public PersonViewModel()
        {
            RefreshData();
        }

        public void Save()
        {
            PersonDao service = new PersonDao();
            if (SelectedPerson.ID > 0)
            {
                if (service.UpdateData(SelectedPerson))
                {
                    RefreshData();
                    MessageBox.Show("Update successful.");
                }
            }
            else
            {
                if (service.InsertData(SelectedPerson))
                {
                    RefreshData();
                    MessageBox.Show("Insert successful.");
                }
            }
        }

        public void Search()
        {
            PersonDao service = new PersonDao();
            Persons.Clear();
            Persons.AddRange(service.FindListByName(SearchName).ConvertAll(d => d as PersonModel));
        }

        public void New()
        {
            SelectedPerson = new PersonModel();
        }

        public void Delete()
        {
            if (MessageBox.Show("Are you sure to delete?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                PersonDao service = new PersonDao();
                if (service.DeleteData(SelectedPerson))
                {
                    RefreshData();
                    New();
                    MessageBox.Show("Delete successful.");
                }
            }
        }

        public void RefreshData()
        {
            PersonDao service = new PersonDao();
            Persons.Clear();
            Persons.AddRange(service.FindListByPage(1, 10).ConvertAll(d => d as PersonModel));
        }

    }

}
