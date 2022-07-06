using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Requests
{
    public class SaveBookRequest : SaveRequest
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
    }
}
