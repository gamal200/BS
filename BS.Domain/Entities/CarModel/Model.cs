using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Domain
{
    public class Model:BaseEntity
    {
        public Model()
        {
            Cars = new HashSet<Car>();
        }
        public string ModelName { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
