using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Web.Services
{
    public class HostTenantIdentificationService : ITenantIdentificationService
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ISchoolService _schoolService;

        public HostTenantIdentificationService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public async Task<School> GetCurrentTenant()
        {
            var host = _accessor.HttpContext.Request.Host;
            var schoolTenant = await _schoolService.GetByDomainAsync(host.ToString());
            return schoolTenant;
        }
    }
}
