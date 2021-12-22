using DependencyInjectionSample.Models;
using DependencyInjectionSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionSample.Controllers
{
    public class OperationsController : Controller
    {
        private readonly OperationService _operationService;
        private readonly IOperationTransient _transientOperation;
        private readonly IOperationScoped _scopedOperation;
        private readonly IOperationSingleton _singletonOperation;

        private readonly OperationService _operationService2;
        private readonly IOperationTransient _transientOperation2;
        private readonly IOperationScoped _scopedOperation2;
        private readonly IOperationSingleton _singletonOperation2;

        public OperationsController(OperationService operationService,
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            OperationService operationService2,
             IOperationTransient transientOperation2,
            IOperationScoped scopedOperation2,
            IOperationSingleton singletonOperation2
            )
        {
            _operationService = operationService;
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;

            _operationService2 = operationService2;
            _transientOperation2 = transientOperation2;
            _scopedOperation2 = scopedOperation2;
            _singletonOperation2 = singletonOperation2;

        }

        public IActionResult Index()
        {
            // ViewBag contains controller-requested services
            ViewBag.T1ransient = _transientOperation;
            ViewBag.S1coped = _scopedOperation;
            ViewBag.S1ingleton = _singletonOperation;


            ViewBag.T2ransient = _transientOperation2;
            ViewBag.S2coped = _scopedOperation2;
            ViewBag.S2ingleton = _singletonOperation2;

            // Operation service has its own requested services
            ViewBag.Service = _operationService;
            return View();
        }
    }
}
