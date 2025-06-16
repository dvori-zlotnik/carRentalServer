using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal
{
    public interface IDal<T>
    {
         Task<List<T>> SelectAllAsync();
         Task<int> AddAsync(T t);
         Task<int> DeleteAsync(int code);

    }
}
