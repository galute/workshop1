using System.Collections.Generic;
using System.Linq;
using Autofac;
using Workshop.Autofac;
using NUnit.Framework;

namespace Tests.Autofac
{

    public class AutofacRegisterGlobalService
    {
        [Test]
        public void TwoRegistrationsSameTypeAndServicesRegisteredOnce()
        {
            var cb = new ContainerBuilder();
            int activated = 0;
            cb.RegisterGlobalService(_ => new OnlyOnce()).As<IDoStuff>().SingleInstance().AutoActivate().OnActivating(_ => activated++);
            cb.RegisterGlobalService(_ => new OnlyOnce()).As<IDoStuff>().SingleInstance().AutoActivate().OnActivating(_ => activated++);
            var container = cb.Build();
            Assert.That(activated, Is.EqualTo(1));
            Assert.That(container.Resolve<IEnumerable<IDoStuff>>().Count(), Is.EqualTo(1));
        }
        [Test]
        public void TwoRegistrationsSameTypeWithoutServiceRegisteredOnce()
        {
            var cb = new ContainerBuilder();
            int activated = 0;
            cb.RegisterGlobalService(_ => new OnlyOnce()).SingleInstance().AutoActivate().OnActivating(_ => activated++);
            cb.RegisterGlobalService(_ => new OnlyOnce()).SingleInstance().AutoActivate().OnActivating(_ => activated++);
            var container = cb.Build();
            Assert.That(activated, Is.EqualTo(1));
            Assert.That(container.Resolve<IEnumerable<OnlyOnce>>().Count(), Is.EqualTo(0));
        }

        [Test]
        public void TwoRegistrationsDifferentTypeSameServiceRegisteredTwice()
        {
            var cb = new ContainerBuilder();
            int activated = 0;
            cb.RegisterGlobalService(_ => new OnlyOnce()).As<IDoStuff>().SingleInstance().AutoActivate().OnActivating(_ => activated++);
            cb.RegisterGlobalService(_ => new AnotherOnlyOnce()).As<IDoStuff>().SingleInstance().AutoActivate().OnActivating(_ => activated++);
            var container = cb.Build();
            Assert.That(activated, Is.EqualTo(2));
            Assert.That(container.Resolve<IEnumerable<IDoStuff>>().Count(), Is.EqualTo(2));
        }

        public interface IDoStuff { }

        public class AnotherOnlyOnce : IDoStuff
        {
            
        }

        public class OnlyOnce : IDoStuff
        {
        }

    }
}
