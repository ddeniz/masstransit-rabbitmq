using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public interface JokerProcessedOk
    {
        string CatalogName { get; set; }
        string CatagoryName { get; set; }
        DateTime Date { get; set; }
        string Message { get; set; }
    }
}
