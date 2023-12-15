//-----------------------------------------------------------------------
// <copyright file="Contracts.cs" company="Lifeprojects.de">
//     Class: Contracts
//     Copyright © Gerhard Ahrens, 2018
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>development@lifeprojects.de</email>
// <date>13.07.2018</date>
//
// <summary>Class for Checking from Mathodes Parameter</summary>
//-----------------------------------------------------------------------

namespace ExtensionsSuite.Standard.Suite
{
    using System;
    using global::System;

    public sealed class Contracts
    {
        public static void Requires(Func<bool> predicate, string message)
        {
            if (!predicate())
            {
                throw new ArgumentException(message);
            }
        }

        public static void Requires<TException>(Func<bool> predicate, string message = "") where TException : Exception, new()
        {
            if (!predicate())
            {
                throw Activator.CreateInstance(typeof(TException), message) as TException;
            }
        }

        public static void Requires<TException>(bool conditon, string message = "") where TException : Exception, new()
        {
            if (!conditon)
            {
                throw Activator.CreateInstance(typeof(TException), message) as TException;
            }
        }

        public static void ThrowIfIsNull<T>(T value) where T : class
        {
            if (value == null)
            {
                var typeName = typeof(T).Name;
                throw new ArgumentNullException($"Parameter value of type {typeName} is not allowed to be null.");
            }
        }

        public static void ThrowIfNull(object target)
        {
            if (target == null)
            {
                var typeName = nameof(target);
                throw new ArgumentNullException($"Parameter value of type {typeName} is not allowed to be null.");
            }
        }

        public static void ThrowIfNullOrEmpty(string target)
        {
            if (string.IsNullOrEmpty(target) == true)
            {
                var typeName = nameof(target);
                throw new ArgumentException($"Parameter value of type {typeName} is not allowed to be null or string empty.");
            }
        }

        public static T CastOrThrow<T>(object value)
        {
            try
            {
                object getAs = value == null ? default : (T)Convert.ChangeType(value, typeof(T));
                if ((getAs.GetType() == typeof(T)) == false)
                {
                    throw new InvalidCastException($"Incorrect type, cannot cast to type {typeof(T).FullName}");
                }

                return (T)getAs;
            }
            catch (Exception)
            {
                throw new InvalidCastException($"Incorrect type, cannot cast to type {typeof(T).FullName}");
            }
        }

        public static T CastOrThrow<T, TException>(object value) where TException : Exception, new()
        {
            try
            {
                object getAs = value == null ? default : (T)Convert.ChangeType(value, typeof(T));
                if ((getAs.GetType() == typeof(T)) == false)
                {
                    throw Activator.CreateInstance(
                        typeof(TException),
                        $"Incorrect type, cannot cast to type {typeof(T).FullName}") as TException;
                }

                return (T)getAs;
            }
            catch (Exception)
            {
                throw new InvalidCastException($"Incorrect type, cannot cast to type {typeof(T).FullName}");
            }
        }

        /*

        public static bool TryCast<T>(object obj, out T result)
        {
            result = default(T);
            if (obj is T)
            {
                result = (T)obj;
                return true;
            }

            if (obj != null)
            {
                try
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    if (converter.CanConvertFrom(obj.GetType()))
                    {
                        result = (T)converter.ConvertFrom(obj);
                    }
                    else
                    {
                        return false;
                    }

                    return true;
                }
                catch (Exception)
                {
                    throw new InvalidCastException($"Incorrect type, cannot cast to type {typeof(T).FullName}");
                }
            }

            return !typeof(T).IsValueType;
        }
        */
    }
}