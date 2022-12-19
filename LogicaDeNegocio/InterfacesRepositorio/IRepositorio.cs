using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDeNegocio.InterfacesRepositorio
{
    public interface IRepositorio<T>
    {
        void Add(T obj);
        void Delete(T obj);
        void Update(T obj);
        T FindById(int id);
        IEnumerable<T> FindAll();



    }
}
