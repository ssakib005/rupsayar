using System;

namespace rupsayar.Models
{
    public interface ITbl_Base
    {
        long Id { get; set; }
        string CreatedBy { get; set; }
        DateTime? CreatedAt { get; set; }
        string ModifyBy { get; set; }
        DateTime? ModifyAt { get; set; }
    }
    public class Tbl_Base : ITbl_Base
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyAt { get; set; }
    }
}