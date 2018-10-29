using SalonAplikacija.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SalonAplikacija.Web.Helpers.Utils
{
    public static class Utils
    {
        public static void CopyObject<TSource,TDestination>(this TSource source,TDestination destination) where TSource:class where TDestination : class
        {
            //Get all properties
            var sourceProps = source.GetType().GetProperties();
            var destinationProps = destination.GetType().GetProperties();

            foreach(var sourceItem in sourceProps)
            {
                foreach(var destItem in destinationProps.Where(x=>x.Name==sourceItem.Name && 
                                                                  (Nullable.GetUnderlyingType(x.PropertyType)??x.PropertyType) == (Nullable.GetUnderlyingType(sourceItem.PropertyType)??sourceItem.PropertyType)))
                {
                    sourceItem.SetValue(source, destItem.GetValue(destination));
                    break;
                }
            }
        }

    }
}
