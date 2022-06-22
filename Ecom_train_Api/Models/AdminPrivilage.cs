using System;
using System.Collections.Generic;

#nullable disable

namespace Ecom_train_Api.Models
{
    public partial class AdminPrivilage
    {
        public int ApId { get; set; }
        public int? ApArId { get; set; }
        public string ApStatus { get; set; }
        public DateTime? ApTs { get; set; }
    }
}
