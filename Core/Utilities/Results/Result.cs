using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult //IResult'ı implemente eden sınıfı oluşturdum, buradakileri genelde constructor üzerinden yönetiriz!
    {

        public Result(bool success, string message) : this(success) //böyle diyerek aşağıdaki constructorı da tetikliyorum! iki parametre gelirse ondan da success i alacak! //bu this ile bu constructor'ın içine tekrar success i yazmamış oldum!
        {
            this.Message = message;
        }
        public Result(bool success)
        {
            this.Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
