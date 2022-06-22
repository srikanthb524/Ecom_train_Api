using System;
using System.Collections.Generic;

#nullable disable

namespace Ecom_train_Api.Models
{
    public partial class AdminRole
    {
        public int ArId { get; set; }
        public string ArName { get; set; }
        public string ArStatus { get; set; }
        public DateTime? ArTs { get; set; }
    }
}
