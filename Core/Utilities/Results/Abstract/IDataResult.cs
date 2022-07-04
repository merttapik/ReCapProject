using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstract
{//result void içindi bu int list gibi değerleride döndürecek
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
