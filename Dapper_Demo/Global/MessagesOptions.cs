using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper_Demo.Global
{
    public class MessagesOptions
    {
        public string AlertMessage { get; set; }
        public string RegularMessage { get; set; }
        public bool ShouldShowAlert { get; set; }
    }
}
