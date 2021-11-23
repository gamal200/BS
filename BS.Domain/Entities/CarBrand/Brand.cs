using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Domain
{
    public class Brand:BaseEntity
    {
        public Brand()
        {
            Models = new HashSet<Model>();
            Cars = new HashSet<Car>();
        }
        public string BrandName { get; set; }
        public ICollection<Model> Models { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
