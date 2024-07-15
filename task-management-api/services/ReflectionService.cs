namespace task_management_api.services
{
    /// <summary>
    /// Provides a static method for reflecting data between objects.
    /// Reflection, in this context, refers to copying the values of properties with the same names from a source object to a target object.
    /// </summary>
    public static class ReflectionService
    {
        /// <summary>
        /// Copies property values from the source object to the target object, provided that the properties have the same names.
        /// This method uses reflection to access properties at runtime.                      
        /// **Important:** The target object must be castable to the source type for successful reflection.
        /// </summary>
        /// <param name="source">The source object that contains the data to be copied.</param>
        /// <param name="target">The target object that will receive the reflected data.</param>
        /// <returns>The modified target object with the reflected properties.</returns>


        public static object Reflect(object source, object target)
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
