using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<out T>:IResult //IDataResult'ın içinde IResult taki success ve message var dedim!
    {
        T Data { get; } //döndürmek istediğim data yı bununla döndüreceğim!
    }
}
