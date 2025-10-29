using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.UseCases
{
    public class CatteryService
    {
        private readonly ICatRepository _repository;
        public CatteryService(ICatRepository repository)
        {
            _repository = repository;
        }

    }
}
