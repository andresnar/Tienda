using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domine.DTO
{
    public class Validator<T>
    {
        public bool ValidateObject(T objeto)
        {
            PropertyInfo[] inPropiedades = typeof(T).GetProperties();
            try
            {
                foreach (PropertyInfo item in inPropiedades)
                {
                    if (!item.Name.Equals("ID"))
                    {
                        if (item.GetValue(objeto) == null || item.GetValue(objeto).ToString() == "0")
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }        
    }
}
