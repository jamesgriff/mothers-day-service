using GovUkDesignSystem;
using GovUkDesignSystem.Attributes.ValidationAttributes;

namespace MothersDayService.Models
{
    public class ChildNameViewModel : GovUkViewModel
    {
        public string YourFirstName { get; set; }

        [GovUkValidateRequired(ErrorMessageIfMissing = "You must enter your child's first name")]
        public string ChildFirstName { get; set; }
    }
}