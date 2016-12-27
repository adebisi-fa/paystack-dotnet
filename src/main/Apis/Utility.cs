namespace PayStack.Net.Apis
{
    public static class Extensions
    {
        public static TD PopulateWith<TS, TD>(this TD destination, TS source)
        {
            var sourceType = typeof(TS);
            var destinationType = typeof(TD);

            foreach (var destinationProperty in destinationType.GetProperties())
            {
                var sourceProperty = sourceType.GetProperty(destinationProperty.Name);

                if (sourceProperty == null)
                    continue;

                destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);
            }

            foreach (var destinationField in destinationType.GetFields())
            {
                var sourceField = sourceType.GetField(destinationField.Name);

                if (sourceField == null)
                    continue;

                destinationField.SetValue(destination, sourceField.GetValue(source));
            }

            return destination;
        }
    }
}