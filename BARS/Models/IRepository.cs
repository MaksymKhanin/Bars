﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARS.Models
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        /// <summary>
        /// получение всех объектов
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetItemsList(); // получение всех объектов
        T GetItem(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
        IEnumerable<T> GetItemsList(int id);
    }
}
