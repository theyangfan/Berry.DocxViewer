using System;
using System.Collections.Generic;
using System.Text;

namespace Berry.DocxViewer
{
    internal static class EnumConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        public static T Convert<T>(this Enum val)
        {
            Type type = val.GetType();
            string fieldname = Enum.GetName(type, val);
            object value = null;
            try
            {
                value = Enum.Parse(typeof(T), fieldname, true);
            }
            catch (Exception)
            {
                throw new InvalidCastException($"{typeof(T).FullName} does not have a field named \"{fieldname}\" !");
            }
            return value != null ? (T)value : default(T);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="val"></param>
        /// <param name="customConvert"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        public static TReturn Convert<T, TReturn>(this T val, Dictionary<T, TReturn> customConvert) where T : Enum
        {
            if(customConvert.ContainsKey(val)) return customConvert[val];
            Type type = val.GetType();
            string fieldname = Enum.GetName(type, val);
            object value = null;
            try
            {
                value = Enum.Parse(typeof(TReturn), fieldname, true);
            }
            catch (Exception)
            {
                throw new InvalidCastException($"{typeof(TReturn).FullName} does not have a field named \"{fieldname}\" !");
            }
            return value != null ? (TReturn)value : default(TReturn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T Convert<T>(this Enum val, T defaultValue)
        {
            Type type = val.GetType();
            string fieldname = Enum.GetName(type, val);
            object value = null;
            try
            {
                value = Enum.Parse(typeof(T), fieldname, true);
            }
            catch (Exception)
            { }
            return value != null ? (T)value : defaultValue;
        }
    }
}
