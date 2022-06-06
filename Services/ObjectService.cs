using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zealandic_Booking.Interfaces;
using Zealandic_Booking.Models;

namespace Zealandic_Booking.Services
{
    public class ObjectService<T> : IObjectService<T> where T : class
    {
        private List<T> objectList;
        private IEnumerable<T> objectEnumlist;

        public DBService<T> DbService { get; set; }

        public ObjectService(DBService<T> dbService)
        {
            DbService = dbService;
            objectList = dbService.GetObjectsAsync().Result.ToList(); 
        }

        public List<T> GetObjectlistAsync()
        {
            objectList = GetObjectsAsync().Result.ToList();
            return objectList;
        }
        public async Task<IEnumerable<T>> GetObjectsAsync()
        {
            return objectList;
        }
        public async Task AddObjectAsync(T obj)
        {
            objectList.Add(obj);
            await DbService.AddObjectAsync(obj);
        }

        public async Task DeleteObjectAsync(T obj)
        {
            objectList.Remove(obj);
            await DbService.DeleteObjectAsync(obj);
        }


        public async Task UpdateObjectAsync(T obj)
        {
            if (obj != null)
            {
                await DbService.UpdateObjectAsync(obj);
            }
        }

        public async Task<T> GetObjectByIdAsync(int id)
        {
            T objToRet= (T)Activator.CreateInstance(typeof(T));
            
            foreach (var Singleobject in objectList)
            {
                string object1value;
                Type t = Singleobject.GetType();
                PropertyInfo prop = t.GetProperty(t+"ID");

                foreach (PropertyInfo property in t.GetProperties())
                {
                    if(t.GetProperty(property.Name) != null)
                    {
                        object1value = t.GetProperty(property.Name).GetValue(Singleobject, null).ToString();
                    }
                }

                var hej = prop.GetValue(Singleobject);
                t.Attributes.ToString();
                //if (t.GetCustomAttributes() == id)
                //{
                //    objToRet = Singleobject;
                //}
            }


            return objToRet;
        }

        
    }
}
