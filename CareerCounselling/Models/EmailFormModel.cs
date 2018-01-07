using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareerCounselling.Models
{
    public class EmailFormModel
    {
        public string FromName { get; set; }
        public string FromSubject { get; set; }
        public string FromEmail { get; set; }
        public string Message { get; set; }

    }
}