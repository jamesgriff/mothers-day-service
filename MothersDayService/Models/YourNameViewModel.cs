using GovUkDesignSystem;
using GovUkDesignSystem.Attributes.ValidationAttributes;

namespace MothersDayService.Models
{
    public class YourNameViewModel : GovUkViewModel
    {
        [GovUkValidateRequired(ErrorMessageIfMissing = "You must enter your first name")]
        public string YourFirstName { get; set; }
    }
}