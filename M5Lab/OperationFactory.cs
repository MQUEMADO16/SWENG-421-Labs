class OperationFactory
{
    public OperationIF create(string className)
    {
        {
            Type type = Type.GetType(className);
            
            if (type == null)
                throw new ArgumentException($"Unknown class: {className}");

            return (OperationIF)Activator.CreateInstance(type);
        }
    }
}