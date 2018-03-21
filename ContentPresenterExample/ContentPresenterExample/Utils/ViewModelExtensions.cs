using System.Diagnostics;

namespace ContentPresenterExample.Utils
{
    public static class ViewModelExtensions
    {

        /// <summary>
        /// If @this is of type T then the extension method will return true, else will return false
        /// </summary>
        /// <typeparam name="T">The desired type</typeparam>
        /// <returns></returns>

        [DebuggerHidden]
        public static bool IsTypeOf<T>(this object @this)
        {
            if (@this is T)
            {
                return true;
            }
            return false;
        }
    }
}