using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eser_Merc.DAL
{
    internal interface IDAL<T>
    {
        List<T> GetAll();
        T findById(int id);
        bool Insert(T t);
        bool Update(T t);
        bool DeleteById(int id);

    }
}
