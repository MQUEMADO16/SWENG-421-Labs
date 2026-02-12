
namespace M5Lab
{
    using System;
    using System.Reflection;

    public class OperationFactory : OperationFactoryIF
    {
        public OperationIF create(string className)
        {
            
            Type ?type = Type.GetType($"M5Lab.{className}");

            if (type == null) 
                throw new ArgumentException($"Unknown class: {className}");
            return (OperationIF)Activator.CreateInstance(type);
        }
    }
}