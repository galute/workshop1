using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Builder;
using Autofac.Core;

namespace Workshop.Autofac
{
    public static class RegisterGlobalServiceExtension
    {

        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> RegisterGlobalService<T>(this ContainerBuilder cb, Func<IComponentContext, T> factory)
        {
            var rb = RegistrationBuilder.ForDelegate((c, p) => factory(c));
            rb.WithMetadata("ctm.registeredonce", rb.ActivatorData.Activator.LimitType);
            cb.RegisterCallback(cr =>
            {
                if (!AlreadyRegistered(rb, cr))
                    RegistrationBuilder.RegisterSingleComponent(cr, rb);
            }); ;
            return rb;
        }

        static bool AlreadyRegistered<T>(IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> rb, IComponentRegistry cr)
        {
            var existingRegistrationsForServices = rb.RegistrationData.Services
                .SelectMany(cr.RegistrationsFor, (registeredService, existing) => existing)
                .Distinct()
                .ToList();
            return existingRegistrationsForServices
                     .Any(_ => _.Metadata.ContainsKey("ctm.registeredonce") && (Type)_.Metadata["ctm.registeredonce"] == rb.ActivatorData.Activator.LimitType);
        }
    }
}