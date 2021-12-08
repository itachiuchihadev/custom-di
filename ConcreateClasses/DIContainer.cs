using System;
using System.Collections.Generic;
using System.Linq;

namespace DIWorks
{
    public class DIContainer
    {
        List<Dependency> _dependencies;
        public DIContainer()
        {
            _dependencies = new List<Dependency>();
        }
        public void AddSingleton<T>(){
            _dependencies.Add(new Dependency(typeof(T), DILifeTime.Singleton));
        }

        public void AddTransient<T>(){
            _dependencies.Add(new Dependency(typeof(T), DILifeTime.Transient));
        }

        public Dependency GetDependency(Type type){
            return _dependencies.First(x => x.Type.Name == type.Name);
        }
        
    }
}