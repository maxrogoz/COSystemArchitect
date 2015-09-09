using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBDataModel
{
    public partial class Log
    {
        [Key]
        public int LogId { get; set; }
        
        [Required]
        [Display(Name = "Time")]
        public System.DateTime LogDateTime { get; set; }

        [Display(Name = "IP Adress")]
        public string IpAddress { get; set; }

        public string Service { get; set; }
        
        public int? MessageType { get; set; }

        public string Message { get; set; }
    }
}
