using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.Model
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
