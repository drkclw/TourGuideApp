using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TourGuideApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TourGuidePageMaster : ContentPage
    {
        public ListView ListView;

        public TourGuidePageMaster()
        {
            InitializeComponent();

            BindingContext = new TourGuidePageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class TourGuidePageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<TourGuidePageMenuItem> MenuItems { get; set; }
            
            public TourGuidePageMasterViewModel()
            {
                MenuItems = new ObservableCollection<TourGuidePageMenuItem>(new[]
                {
                    new TourGuidePageMenuItem { Id = 0, Title = "Page 1" },
                    new TourGuidePageMenuItem { Id = 1, Title = "Page 2" },
                    new TourGuidePageMenuItem { Id = 2, Title = "Page 3" },
                    new TourGuidePageMenuItem { Id = 3, Title = "Page 4" },
                    new TourGuidePageMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}