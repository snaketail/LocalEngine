using System;

namespace BaseClass
{
    public class Product
    {
        public string id { get; private set; }
        public string name { get; private set; }

        public string description { get; private set; }
        public string productKey { get; set; }

        public Product(string _name, string _description)
        {
            id = ProductIdGen();   
            name = _name;   
            description = _description; 
        }
        private string ProductIdGen()
        {
            return "UUID_Product";
        }

        public  void SetKey(string _key)
        {
            productKey = _key;
        }
    }
}
