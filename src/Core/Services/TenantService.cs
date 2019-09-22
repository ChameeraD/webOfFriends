using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantIdentificationService _service;
        public TenantService(ITenantIdentificationService service)
        {
            _service = service;
        }

        public async Task<School> GetCurrentTenant()
        {
            return await _service.GetCurrentTenant();
        }
    }
}
