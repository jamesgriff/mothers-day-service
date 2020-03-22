using GovUkDesignSystem;
using GovUkDesignSystem.Attributes;
using GovUkDesignSystem.Attributes.ValidationAttributes;

namespace MothersDayService.Models
{
    public class DoYouHaveAChildViewModel : GovUkViewModel
    {
        [GovUkValidateRequired(ErrorMessageIfMissing = "You must select whether or not you have a child")]
        public DoYouHaveAChild? DoYouHaveAChild { get; set; }
    }

    public enum DoYouHaveAChild
    {
        [GovUkRadioCheckboxLabelText(Text = "Yes, I have a child")]
        Yes,
        [GovUkRadioCheckboxLabelText(Text = "No, I do not have a child")]
        No
    }
}