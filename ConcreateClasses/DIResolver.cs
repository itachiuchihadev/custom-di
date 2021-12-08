using System;
using System.Linq;
using System.Reflection;

namespace DIWorks
{
    public class DIResolver
    {
        public DIContainer dIContainer;
        public DIResolver(DIContainer dIContainer)
        {
            this.dIContainer = dIContainer;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        public object GetService(Type type)
        {
            var dependency = dIContainer.GetDependency(type);
            var constructor = dependency.Type.GetConstructors().Single();
            var parametersOfConstructors = constructor.GetParameters().ToArray();
            if (parametersOfConstructors.Length > 0)
            {
                var parameterImplementations = new object[parametersOfConstructors.Length];
                for (int i = 0; i < parametersOfConstructors.Length; i++)
                {
                    parameterImplementations[i] = GetService(parametersOfConstructors[i].ParameterType);
                }
                return CreateImplementation(dependency, t => Activator.CreateInstance(t, parameterImplementations));
            }
            return CreateImplementation(dependency, t => Activator.CreateInstance(t));
        }

        public object CreateImplementation(Dependency dependency, Func<Type, object> factory)
        {

            if (dependency.IsImplemented)
            {
                return dependency.Implementation;
            }
            var implementation = factory(dependency.Type);
            if (dependency.DILifeTime == DILifeTime.Singleton)
            {
                dependency.AddImplentation(implementation);
            }
            return implementation;
        }



    }
}