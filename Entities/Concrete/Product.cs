using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //internal class: sadece bu entities altında kullanılabilir demek!

    //protected: sadece inherit ettiği yerde kullanılır! (classlarda protected ve private olmaz!)
    public class Product:IEntity //kalıtım içermeyen classlardan korkmalısın o yüzden burada IEntity den miras alıp bu da her projede kullanılabilecek bir şey olduğundan core katmanının içine yerleştiriyorum! add reference to core yaparak referansa ekle!
        //public ile diğer library lerden erişebilirsin dedim!
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string  QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }

    }
}
