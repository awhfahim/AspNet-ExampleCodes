using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class MyORM<G, T>
        where T : class
    {
        public void Insert(T entity)
            => InsertEntity(entity);

        public void Update(T entity)
            => UpdateEntity(entity);

        public void Delete(T entity)
        {
            var id_val = entity.GetType().GetProperty("Id")!.GetValue(entity);
            DeleteEntity(entity.GetType(), ("Id", id_val!));
        }

        public ICollection<T> GetAll()
        {
            IList<T> entities = new List<T>();
            AdoNetUtililty adoNetUtil = new();
            var data = adoNetUtil.GetAll(typeof(T).Name);
            foreach (var entity in data)
            {
                var constructor = typeof(T).GetConstructors().FirstOrDefault();
                var instance = constructor?.Invoke(new object[] { });

                if (instance is not null)
                {
                    foreach (var property in entity)
                    {
                        var property_info = instance.GetType().GetProperty(property.columnName);
                        if(property_info is not null)
                            property_info.SetValue(instance, property.value);
                    }
                }

                foreach (var property in typeof(T).GetProperties())
                {
                    var propertyType = property.PropertyType;
                    if (!IsPrimitive(propertyType))
                    {
                        var result = GetAllEntity(propertyType, typeof(T).Name + "Id",
                         instance!.GetType().GetProperty("Id")!.GetValue(instance)!);

                        property.SetValue(instance, result);
                    }
                }

                entities.Add(instance as T);
            }

            return entities;
        }

        public void Delete(G id)
            => DeleteEntity(typeof(T), ("Id", id!));

        public T GetById(G id)
        {
            AdoNetUtililty adoNetUtil = new();
            var data = adoNetUtil.GetById(typeof(T).Name, "Id", id);

            var constructor = typeof(T).GetConstructors().FirstOrDefault();
            var instance = constructor?.Invoke(new object[] { });

            foreach (var entity in data)
            {             
                if (instance is not null)
                {
                    foreach (var property in entity)
                    {
                        var property_info = instance.GetType().GetProperty(property.columnName);
                        if (property_info is not null)
                            property_info.SetValue(instance, property.value);
                    }
                }

                foreach (var property in typeof(T).GetProperties())
                {
                    var propertyType = property.PropertyType;
                    if (!IsPrimitive(propertyType))
                    {
                        var result = GetAllEntity(propertyType, typeof(T).Name + "Id",
                         instance!.GetType().GetProperty("Id")!.GetValue(instance)!);

                        property.SetValue(instance, result);
                    }
                }
            }

            return instance as T;
        }

        private object GetAllEntity(Type type, string keyName, object id)
        {
            AdoNetUtililty adoNetUtil = new();         

            if (type.GetInterfaces().Contains(typeof(IList)))
            {
                var propertyTypeName = type.GetGenericArguments().First();
                var data = adoNetUtil.GetById(propertyTypeName.Name, keyName, id);

                Type listType = typeof(List<>).MakeGenericType(propertyTypeName);
                var myList = listType.GetConstructors().FirstOrDefault()!.Invoke(new object[] { });

                foreach(var value in data)
                {
                    var instance = propertyTypeName.GetConstructors().FirstOrDefault()!.Invoke(new object[] { });
                    foreach(var item in value)
                    {
                        var propertyInstance = instance.GetType().GetProperty(item.columnName);
                        if (propertyInstance is not null)
                            propertyInstance.SetValue(instance, item.value);
                    }

                    foreach (var property in propertyTypeName.GetProperties())
                    {
                        var propertyType = property.PropertyType;
                        if (!IsPrimitive(propertyType))
                        {
                            var val = instance.GetType().GetProperty("Id")!.GetValue(instance);
                            var result = GetAllEntity(propertyType, propertyTypeName.Name + "Id", val);

                            instance.GetType().GetProperty(property.Name)!.SetValue(instance, result);
                        }
                    }

                    myList.GetType().GetMethod("Add")!.Invoke(myList, new object[] { instance });
                }

                return myList;
            }
            else
            {
                var data = adoNetUtil.GetById(type.Name, keyName, id);
                var instance = type.GetConstructors().FirstOrDefault()!.Invoke(new object[] { });

                foreach(var value in data)
                {
                    foreach (var item in value)
                    {
                        var propertyInstance = instance.GetType().GetProperty(item.columnName);
                        if (propertyInstance is not null)
                            propertyInstance.SetValue(instance, item.value);
                    }
                }

                if (data.Count > 0) 
                {
                    foreach (var property in type.GetProperties())
                    {
                        var propertyType = property.PropertyType;
                        if (!IsPrimitive(propertyType))
                        {
                            var val = instance.GetType().GetProperty("Id").GetValue(instance);
                            var result = GetAllEntity(propertyType, type.Name + "Id", val);

                            instance.GetType().GetProperty(property.Name)!.SetValue(instance, result);
                        }
                    }
                }

                return instance;

            }
        }

        private void DeleteEntity(Type entity, (string name, object id) key)
        {
            try
            {
                AdoNetUtililty adoNetUtililty = new();

                foreach(var property in entity
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static))
                 {
                    var entityName = entity.Name;

                    if (property.PropertyType.GetInterfaces().Contains(typeof(IList)))
                    {
                        var propertyType = property.PropertyType.GetGenericArguments().First();

                        foreach(var id in
                            adoNetUtililty.GetPrimaryKey(propertyType.Name, entityName + "Id", key.id))
                        {
                            DeleteEntity(propertyType, ("Id", id));
                        }

                    }

                    else
                    {
                        if (!IsPrimitive(property.PropertyType))
                        {
                            var propertyType = property.PropertyType;
                            foreach(var id in adoNetUtililty
                                .GetPrimaryKey(propertyType.Name, entityName + "Id", key.id))
                                DeleteEntity(propertyType, ("Id", id));
                        }
                    }
                }
                
                adoNetUtililty.DeleteById(entity.Name,key.name, key.id);
            }
            catch(Exception ex) { throw new Exception(ex.Message, ex); }
        }

        private void UpdateEntity(object entity)
        {
            AdoNetUtililty adoNetUtililty = new();
            var dictionary = new Dictionary<string, object>();

            try
            {
                var properties = entity.GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

                foreach(var property in properties)
                {
                    if (IsPrimitive(property.PropertyType)
                        && property.GetValue(entity) is object value)
                    {
                         dictionary.Add(property.Name, value);
                    }
                }
                var key = properties.Where(x => x.Name == "Id").First().GetValue(entity);
                adoNetUtililty.Update(entity.GetType().Name, dictionary, key!);

                foreach (var property in properties)
                {
                    if (property.PropertyType.GetInterfaces().Contains(typeof(IList)))
                    {
                        if (property.GetValue(entity) is IList items)
                        {
                            foreach (var item in items)
                            {
                                UpdateEntity(item);
                            }
                        }
                    }

                    else
                    {
                        if (!IsPrimitive(property.PropertyType) 
                            && property.GetValue(entity) is object propertyValue)
                        {
                            UpdateEntity(propertyValue);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void InsertEntity(object entity, params string[] key)
        {
            var dictionary = new Dictionary<string, object>();
            var utility = new AdoNetUtililty();

            if (key.Length is 2)
                dictionary[key[0]] = key[1];

            try
            {
                var properties = entity.GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

                foreach (var property in properties)
                {
                    if (IsPrimitive(property.PropertyType) 
                        && property.GetValue(entity) is object propertyValue)  
                            dictionary.Add(property.Name, propertyValue);
                }
                //utility.Insert(entity.GetType().Name, dictionary);

                foreach (var property in properties)
                {
                    if (property.PropertyType.GetInterfaces().Contains(typeof(IList))
                        && property.GetValue(entity) is IList items)
                    {
                        foreach (var item in items)
                        {   
                            var p_key = GetPrimaryKey(entity);
                            InsertEntity(item, p_key.Name, p_key.Value);
                        }
                    }

                    else
                    {
                        if(!IsPrimitive(property.PropertyType) 
                            && property.GetValue(entity) is object propertyValue)
                        {
                            dictionary.Add(property.Name, propertyValue);
                            var p_key = GetPrimaryKey(entity);
                            InsertEntity(propertyValue, p_key.Name, p_key.Value);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private bool IsPrimitive(Type type)
            => type.IsPrimitive || type == typeof(Guid) || type == typeof(string)
               || type == typeof(DateTime) || type == typeof(DateTimeOffset) || type.IsEnum || !type.IsClass
               ? true 
               : false;

        private (string Name,string Value) GetPrimaryKey(object entity)
        {
            string val = entity.GetType().GetProperty("Id")!.GetValue(entity)!.ToString()!;
            string name = entity.GetType()?.Name + "Id";
            return (name, val);
        }
        
    }
}
