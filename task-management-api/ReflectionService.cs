namespace task_management_api
{
    public static class ReflectionService
    {

        public static object Reflection(object source,object target) 
        {
            var targetProperties = target.GetType().GetProperties();

            var sourceProperties = source.GetType().GetProperties();

            foreach (var property in sourceProperties)
            {
                var targetProperty = targetProperties.FirstOrDefault(p => p.Name == property.Name);

                if (targetProperty != null)
                {
                    var targetValue = targetProperty.GetValue(target);

                    var sourceValue = property.GetValue(source);
                    if (targetValue != sourceValue)
                    {
                        targetProperty.SetValue(target, sourceValue);
                    }
                }            
            }
            return target;
        }
    }
}
