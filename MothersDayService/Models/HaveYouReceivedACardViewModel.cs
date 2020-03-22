using GovUkDesignSystem;
using GovUkDesignSystem.Attributes;
using GovUkDesignSystem.Attributes.ValidationAttributes;

namespace MothersDayService.Models
{
    public class HaveYouReceivedACardViewModel : GovUkViewModel
    {
        [GovUkValidateRequired(ErrorMessageIfMissing = "You must select whether or not your child sent you a card")]
        public HaveYouReceivedACard? HaveYouReceivedACard { get; set; }
    }

    public enum HaveYouReceivedACard
    {
        [GovUkRadioCheckboxLabelText(Text = "Yes, I have received a card")]
        CardReceived,
        [GovUkRadioCheckboxLabelText(Text = "No, my child left it too late to sent me a card")]
        CardNotReceived
    }
}