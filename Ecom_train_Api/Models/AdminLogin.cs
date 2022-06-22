using System;
using System.Collections.Generic;

#nullable disable

namespace Ecom_train_Api.Models
{
    public partial class AdminLogin
    {
        public int AId { get; set; }
        public string AUsername { get; set; }
        public string APassword { get; set; }
        public int? AArId { get; set; }
        public string AStatus { get; set; }
        public DateTime? ATs { get; set; }
    }
}
