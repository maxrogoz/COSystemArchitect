using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

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

        [EnumDataType(typeof(EventLogEntryType))]
        public EventLogEntryType? MessageType { get; set; }

        public string Message { get; set; }
    }
}
