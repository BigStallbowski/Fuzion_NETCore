using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fuzion.UI.Persistence.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Fuzion.UI.Apis
{
    [Route("api/hardwaretypes")]
    public class HardwareTypesController : Controller
    {
        private IUnitOfWork _uow;
        private ILogger _logger;

        public HardwareTypesController(IUnitOfWork uow, ILoggerFactory loggerFactory)
        {
            _uow = uow;
            _logger = loggerFactory.CreateLogger(nameof(HardwareTypesController));
        }
    }
}