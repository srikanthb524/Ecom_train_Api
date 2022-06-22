using System;
using System.Collections.Generic;

#nullable disable

namespace Ecom_train_Api.Models
{
    public partial class ItemGroup
    {
        public int IgId { get; set; }
        public string IgName { get; set; }
        public string IgStatus { get; set; }
        public DateTime? IgTs { get; set; }
    }
}
