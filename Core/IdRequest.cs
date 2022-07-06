using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class IdRequest : IRequest
    {
        public int Id { get; set; }
        public IdRequest(int id)
        {
            Id = id;
        }
        public IdRequest()
        {

        }
    }
}
