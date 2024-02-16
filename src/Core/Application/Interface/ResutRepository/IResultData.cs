using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.ResutRepository;

public interface IResultData<T>
{
    bool IsSuccess { get; }
    string Message { get; }
    T Data { get; }

    public IResultData<T> SetData(T data);
}
