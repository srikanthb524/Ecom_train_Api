using System;
using System.Collections.Generic;

#nullable disable

namespace Ecom_train_Api.Models
{
    public partial class ItemPriceDetail
    {
        public int IpdId { get; set; }
        public int? IpdIId { get; set; }
        public double? IpdMrp { get; set; }
        public double? IpdMarketPrice { get; set; }
        public double? IpdDiscount { get; set; }
        public DateTime? IpdStartDate { get; set; }
        public DateTime? IpdEndDate { get; set; }
        public string IpdStatus { get; set; }
        public DateTime? IpdTs { get; set; }
    }
}
