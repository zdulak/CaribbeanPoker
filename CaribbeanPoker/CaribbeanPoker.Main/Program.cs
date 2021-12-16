using System;
using System.Reflection;
using Autofac;
using CaribbeanPoker.Main;

namespace CaribbeanPoker.Main
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            var container = ConfigureContainer();
            var game = container.Resolve<Game>();
            game.Run();
        }

        static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Game>().AsSelf();
            builder.RegisterType<Hand>().AsSelf();
            builder.RegisterType<Random>().AsSelf();
            builder.RegisterType<View>().As<IView>().SingleInstance();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<IDependency>().AsImplementedInterfaces().InstancePerDependency();
            return builder.Build();
        }
    }
}
