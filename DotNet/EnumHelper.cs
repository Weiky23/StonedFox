using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StonedFox.DotNet
{
    public static class EnumHelper
    {
        public static T[] GetEnumValues<T>() where T : struct
        {
            IList audioEvents;
            try
            {
                audioEvents = Enum.GetValues(typeof(T));
            }
            catch (ArgumentException e)
            {
                Debug.LogError("Это не enum " + typeof(T));
                return new T[0];
            }
            T[] values = new T[audioEvents.Count];
            for (int i = 0; i < audioEvents.Count; i++)
            {
                values[i] = (T)audioEvents[i];
            }
            return values;
        }

        public static string[] GetEnumToStringValues<T>() where T : struct
        {
            T[] enumValues = GetEnumValues<T>();
            string[] enumStringValues = new string[enumValues.Length];
            for (int i = 0; i < enumStringValues.Length; i++)
            {
                enumStringValues[i] = enumValues[i].ToString();
            }
            return enumStringValues;
        }
    }
}