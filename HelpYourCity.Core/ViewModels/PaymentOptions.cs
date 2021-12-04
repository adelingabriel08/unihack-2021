using System.Collections.Generic;

namespace HelpYourCity.Core.ViewModels
{
    public class PaymentOptions
    {
        public string SuccessUrl { get; set; }
        public string CancelUrl { get; set; }
        public List<object> LineItems { get; set; }
        public string Mode { get; set; }
        public string CustomerEmail { get; set; }
        public string SubmitType { get; set; }
    }
}