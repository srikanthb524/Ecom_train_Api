using System;
using System.Collections.Generic;

#nullable disable

namespace Ecom_train_Api.Models
{
    public partial class ItemPrivilage
    {
        public int IId { get; set; }
        public string IName { get; set; }
        public int? IIgId { get; set; }
        public string IDesc { get; set; }
        public string IImage { get; set; }
        public string IStatus { get; set; }
        public DateTime? ITs { get; set; }
    }
}
