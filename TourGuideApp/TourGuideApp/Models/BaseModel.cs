using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TourGuideApp.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsBusy { get; protected set; }
    }
}
