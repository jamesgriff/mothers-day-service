using System.Collections.Generic;
using GovUkDesignSystem;
using GovUkDesignSystem.Attributes;
using GovUkDesignSystem.Attributes.ValidationAttributes;

namespace MothersDayService.Models
{
    public class GreetingsViewModel : GovUkViewModel
    {
        public string YourFirstName { get; set; }
        public string ChildFirstName { get; set; }

        [GovUkValidateRequired(ErrorMessageIfMissing = "You must enter your first name")]
        public List<Greetings> Greetings { get; set; }
    }

    public enum Greetings
    {
        [GovUkRadioCheckboxLabelText(Text = "Your child considers you to be the best mum in the world")]
        BestMumInTheWorld,
        [GovUkRadioCheckboxLabelText(Text = "Your child would like you to have a lovely, relaxing day")]
        HaveARelaxingDay
    }
}