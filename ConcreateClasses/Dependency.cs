using System;

namespace DIWorks
{
    public class Dependency
    {
        public Dependency(Type t, DILifeTime lifeTime)
        {
            Type = t;
            DILifeTime = lifeTime;
        }
        public DILifeTime DILifeTime{ get; set;}
        public Type Type { get; set; }
        public object Implementation { get; set; }
        public bool IsImplemented { get; set; }
        public void AddImplentation(object implementation){
            Implementation = implementation;
            IsImplemented = true;
        }

    }
}