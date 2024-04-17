using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWC_DatabaseLayer.Mapper
{
    public interface IMapper<T, V>
    {
        public V Map(T data);
        public T Unmap(V data);
    }
}
