using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TourGuideApp.Models
{
    public class ValidatableModel<T> : BaseModel
    {
        public List<IValidationRule<T>> Validations { get; } = new List<IValidationRule<T>>();
        public T Value { get; set; }

        void OnValueChanged() => propertyChangedCallback?.Invoke();

        readonly Action propertyChangedCallback;

        public ValidatableModel(Action propertyChangedCallback = null, params IValidationRule<T>[] validations)
        {
            this.propertyChangedCallback = propertyChangedCallback;
            foreach (var val in validations)
                Validations.Add(val);
        }

        [DependsOn(nameof(Value))]
        public bool IsValid => Validations.TrueForAll(v => v.Validate(Value));

        public string ValidationDescriptions => string.Join(Environment.NewLine, Validations.Select(v => v.Description));
    }
}
