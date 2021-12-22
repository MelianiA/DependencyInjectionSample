using System;

namespace DependencyInjectionSample.Models
{
    public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton, IOperationSingletonInstance
    {
        Guid _guid;
        public Guid OperationId => _guid;

        public Operation() : this(Guid.NewGuid())
        {
        }

        public Operation(Guid guid)
        {
            _guid = guid;
        }

    }
}
