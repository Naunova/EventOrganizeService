using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizeDataModel
{
    public class NotFoundExeption:ApplicationException
    {
        public NotFoundExeption(string message):base(message)
        {
            
        }
        public NotFoundExeption(string message, Exception exception)
            :base(message, exception)
        {
            
        }

    }

    
}
