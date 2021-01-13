using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Model;

namespace WpfApp1.Core
{
    public class JsonHandler
    {
        string fileName = @"c:\temp\cars.json";

        public bool Write(List<Car> cars)
        {
            try
            {
                System.IO.File.WriteAllText(fileName, JsonConvert.SerializeObject(cars));
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<Car> Read()
        {
            List<Car> cars = new List<Car>();
            try
            {

                string content = System.IO.File.ReadAllText(fileName);
                cars = JsonConvert.DeserializeObject<List<Car>>(content);
            }
            catch (Exception ex)
            {
            }
            return cars;
        }
    }
}
