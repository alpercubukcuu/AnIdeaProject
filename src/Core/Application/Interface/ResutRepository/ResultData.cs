using Application.Interface.ResutRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.ResutRepository;

public class ResultData<T> : IResultData<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T Data { get; private set; }

    public IResultData<T> SetData(T data)
    {
        this.Data = data;
        return this;
    }

    // Başarılı sonuç için fabrika metodu
    public static ResultData<T> Success(T data)
    {
        return new ResultData<T> { IsSuccess = true, Data = data };
    }

    // Başarısız sonuç için fabrika metodu
    public static ResultData<T> Failure(string message)
    {
        return new ResultData<T> { IsSuccess = false, Message = message };
    }
}
