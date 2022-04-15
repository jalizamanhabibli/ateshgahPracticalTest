using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PracticalTest.Core.Dtos;
using PracticalTest.Core.Entities;
using PracticalTest.Core.Repositories;
using PracticalTest.Core.Repositories.Client;
using PracticalTest.Core.Services;
using Serilog;

namespace PracticalTest.Service.Services
{
    public class ClientService:IClientService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public ClientService(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDto>> GetAll()
        {
            try
            {
                Log.Information("Start GetAll");
                var result = await _uniteOfWork.ClientRepository.GetAll().ToListAsync();
                var resultDto = _mapper.Map<IEnumerable<ClientDto>>(result);
                Log.Information("End GetAll");
                return resultDto;
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Error GetAll");
                throw;
            }
            
        }
    }
}