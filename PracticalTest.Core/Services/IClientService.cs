using System.Collections.Generic;
using System.Threading.Tasks;
using PracticalTest.Core.Dtos;
using PracticalTest.Core.Entities;

namespace PracticalTest.Core.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAll();
    }
}