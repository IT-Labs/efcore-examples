using Contracts.Requests;
using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Managers
{
    public interface IBookManager
    {
        Response<Book> Get(int id);
        PagedResponse<Book> Get(PageRequest reqest);
        Response<int> Save(SaveBookRequest request);
    }
}
