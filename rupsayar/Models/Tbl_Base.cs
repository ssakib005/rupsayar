using System;

namespace rupsayar.Models
{
    public class Tbl_Base
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyAt { get; set; }
    }
}