using System;
using System.Collections.Generic;
using System.Text;

namespace TourGuideApp.Models
{
    public interface IValidationRule<T>
    {
        string Description { get; }
        bool Validate(T value);
    }
}
