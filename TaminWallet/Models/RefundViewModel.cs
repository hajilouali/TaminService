using System.ComponentModel.DataAnnotations;

namespace TaminWallet.Models
{
    public class RefundViewModel
    {
        [Display(Name = "Tracking number")]
        public long TrackingNumber { get; set; }
    }
}
