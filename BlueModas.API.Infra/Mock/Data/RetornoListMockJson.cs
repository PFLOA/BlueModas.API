using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlueModas.API.Infra.Mock.Data
{
    public class RetornoListMockJson<T>
    {
        public static List<T> RetornoList(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string retorno = ""; 

                while (reader.Peek() >= 0)
                {
                    retorno += reader.ReadLine(); 
                }

                return JsonConvert.DeserializeObject<List<T>>(retorno);
            }
        }
    }
}
