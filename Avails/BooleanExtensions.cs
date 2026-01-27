namespace CP.Client.Core.Avails
{
    public static class BooleanExtensions
    {
        public static bool Not(this bool value)
        {
            return Shared.Primitives.Avails.Extensions.BooleanExtensions.Not(value);
        }
    }
}