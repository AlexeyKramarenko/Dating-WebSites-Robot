using Infrastructure.Models;
using Localization;

namespace WpfApp.Badoo
{
    public class DialogProperty
    {
        public bool IsChecked { get; set; }
        public string Text { get; set; }
    }
        
    public class DialogViewModel
    {
        public Sex[] PossibleSexTypes => new Sex[]
        {
            Sex.Man,
            Sex.Woman
        };

        public Sex SelectedSex { get; set; }

        public Search[] PossibleSearchLocations => new Search[]
        {
            Search.Encounters,
            Search.PeopleNearby
        };

        public Search SelectedSearchLocation { get; set; }

        public DialogProperty IsFree { get; set; }
        public DialogProperty DoesntHaveKids { get; set; }
        public DialogProperty IsNonSmoker { get; set; }

        public DialogViewModel()
        {
            IsFree = new DialogProperty
            {
                Text = "The person should be free"
            };

            DoesntHaveKids = new DialogProperty
            {
                Text = "The person should be without kids"
            };

            IsNonSmoker = new DialogProperty
            {
                Text = "The person should be non-smoker"
            };
        }
    }
}

