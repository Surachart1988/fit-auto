using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Injection
{
    public interface IBaseCardService<T>
    {
        List<IdNameModel> GetKeySearchList();

        T Get(string code, string branchNo);

        string GetDocNo(string branchNo);

        void Create(T model);

        void Update(T model);

        void Delete(string code, string branchNo);

        void Submit(T model);
    }
}
