using _MAINGAME.Scripts.AppScripts.Utilities.Attributes;
using _MAINGAME.Scripts.AppScripts.Utilities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace _MAINGAME.Scripts.AppScripts.Utilities.Behaviours
{
    public static class ApplicationBehaviourUtils
    {
        public static void SetupSingleton(object obj)
        { 
            var type = obj.GetType();
            var singletonAtt = type.GetCustomAttribute<_MAINGAME.Scripts.AppScripts.Utilities.Attributes.SingletonAttribute>();
            if(singletonAtt == null)
            {
                return;
            }

            var types = singletonAtt.Types;
            if(types == null)
            {
                SingletonContainer.Instance.RegistrySingleton(obj, type);
            }
            else
            {
                SingletonContainer.Instance.RegistrySingleton(obj, types);
            }
        }

        public static void InjectComponents(object obj)
        {

            var type = obj.GetType();
            foreach(var field in GetFieldsWithAttribute(type, typeof(InjectAttribute)))
            {
                var fieldType = field.FieldType;
                void AssignCb(object o)
                {
                    field.SetValue(obj, o);
                    var hook = field.GetCustomAttribute<InjectAttribute>().Hook;
                    if (hook is null)
                        return;
                    var hookMethod = type.GetMethod(hook, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    hookMethod?.Invoke(obj, new[] { o });
                }
                SingletonContainer.Instance.GetSingleton(fieldType, AssignCb);
            }
        }

        public static IEnumerable<FieldInfo> GetFieldsWithAttribute(Type selfType, Type attributeType)
        {
            var fields = selfType.
                        GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).
                        Where(fields => fields.GetCustomAttribute(attributeType, true) is not null);
            return fields;
        }
    }
}
