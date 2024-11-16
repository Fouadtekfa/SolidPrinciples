using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipeI
{
    public interface IWriteIRepository
    {
        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);
        Task Save();
    }
}
