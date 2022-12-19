using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDeNegocioUsuarios
{
    public interface IRepositorioU<T>
    {
        void Add(T obj);
        void Delete(T obj);
        void Update(T obj);
        T FindById(int id);
        IEnumerable<T> FindAll();



    }
}
