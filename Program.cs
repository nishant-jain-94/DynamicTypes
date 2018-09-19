using System;
using System.Reflection;
using Newtonsoft.Json;

namespace DynamicTypes
{
    class Test 
    {
        public string Name { get; set; }
        public void DisplayName()
        {
            Console.WriteLine(this.Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var jsonString = "{'Name': 'Rahul'}";
            var type = Type.GetType("DynamicTypes.Test");
            object instanceObject = Activator.CreateInstance(type);
            JsonConvert.PopulateObject(jsonString, instanceObject);
            type.InvokeMember("DisplayName", BindingFlags.InvokeMethod, null, instanceObject, new object[0]);
            Console.WriteLine("Hello World!");
        }
    }
}
