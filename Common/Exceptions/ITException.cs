using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
   public  class ITException:Exception
    {
        public ITException()
        {

        }
        public ITException(string mass) : base(mass)
        {

        }
        
        public ITException(string message, Exception innerException) : base(message)
        {

        }
        public class ITError
        {
            public int code { get; set; }
            public string massage { get; set; }
        }
    }
}
