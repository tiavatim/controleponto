using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePonto.Helpers
{
    public class AjaxActionResult
    {
        public bool isOk { get; set; }
        public string message { get; set; }
        public object bag { get; set; }
    }
}
