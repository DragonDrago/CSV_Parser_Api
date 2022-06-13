using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSV_Parser_Api.Services
{
    public class Counter
    {
        public int InsertedItems { get; set; }
        public Counter(int? InitialValue)
        {
            InsertedItems = InitialValue.HasValue ? InitialValue.Value : 0;
        }
        public void Increment()
        {
            InsertedItems++;
        }
    }
}