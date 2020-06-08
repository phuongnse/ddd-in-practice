using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DDDInPractice.Logic.Common
{
    public static class DomainEvents
    {
        private static IList<Type> _handlers;

        public static void Init()
        {
            _handlers = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => type
                    .GetInterfaces()
                    .Any(iType => iType.IsGenericType && iType.GetGenericTypeDefinition() == typeof(IHandler<>)))
                .ToList();
        }

        public static void Dispatch(IDomainEvent domainEvent)
        {
            foreach (var handlerType in _handlers)
            {
                var canHandle = handlerType
                    .GetInterfaces()
                    .Any(type =>
                        type.IsGenericType &&
                        type.GetGenericTypeDefinition() == typeof(IHandler<>) &&
                        type.GenericTypeArguments.First() == domainEvent.GetType());

                if (!canHandle)
                    continue;

                dynamic handler = Activator.CreateInstance(handlerType);

                if (handler == null)
                    continue;

                handler.Handle((dynamic) domainEvent);
            }
        }
    }
}