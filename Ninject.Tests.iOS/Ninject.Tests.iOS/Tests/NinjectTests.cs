using System;
using Ninject;
using NUnit.Framework;
using Ninject.Modules;

namespace Ninject.Tests.iOS
{
    [TestFixture]
    public class NinjectTests
    {
        class Clazz : InYourFace
        {
        }

        interface InYourFace
        {
        }

        class Module : NinjectModule
        {
            public override void Load()
            {
                this.Bind<InYourFace>().To<Clazz>();
            }
        }

        [Test]
        public void StandardImport()
        {
            var kernel = new StandardKernel(new Module());

            var inYourFace = kernel.Get<InYourFace>();

            Assert.IsNotNull(inYourFace);
        }
    }
}

