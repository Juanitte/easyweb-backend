namespace EasyWeb.TicketsMicroservice.Utilities
{
    public static class Extension
    {
        //
        // Resumen:
        //     Checks whether enumerable is null or empty.
        //
        // Parámetros:
        //   enumerable:
        //     The System.Collections.Generic.IEnumerable`1 to be checked.
        //
        // Parámetros de tipo:
        //   T:
        //     The type of the enumerable.
        //
        // Devuelve:
        //     True if enumerable is null or empty, false otherwise.
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable != null)
            {
                return !enumerable.Any();
            }

            return true;
        }
    }
}
