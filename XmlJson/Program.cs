using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace XmlJson
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> listUser = new List<User>
            {
                new User
                {
                    Login="anuar.temirbolat",
                    Password="asd123"
                },
                new User
                {
                    Login="temirbolat.anuar",
                    Password="234sdf"
                }
            };
            List<Product> listProduct = new List<Product>
            {
                new Product
                {
                    Name="картошка",
                    Price=90
                },
                new Product
                {
                    Name="Огурцы",
                    Price=400
                }
            };
            Basket basket1 = new Basket() {User=listUser[0],ListProduct=new List<Product>() };
            Basket basket2 = new Basket() { User=listUser[1], ListProduct = new List<Product>() };

             for(int i = 0; i < listProduct.Count; i++)
             {
                 basket1.ListProduct.Add(listProduct[i]);
                 basket2.ListProduct.Add(listProduct[i]);
             }
         
            var xmlDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Baskets"));         
            foreach(var item in basket1.ListProduct)
            {
                xmlDoc.Root.Add(new XElement("user",
                    new XAttribute("login", basket1.User.Login),
                    new XElement("price", item.Price),
                    new XElement("product", item.Name)));                
            }

            foreach (var item in basket2.ListProduct)
            {
                xmlDoc.Root.Add(new XElement("user",
                    new XAttribute("login", basket2.User.Login),
                    new XElement("price", item.Price),
                    new XElement("product", item.Name)));
            }
            xmlDoc.Save("data2.xml");

            string serialized = JsonConvert.SerializeObject(basket1);
            serialized+= JsonConvert.SerializeObject(basket2);
            string fileName1 = "data3.json";
            if (!File.Exists(fileName1))
            {
                File.Create(fileName1).Close();
            }            
            File.WriteAllText(fileName1, serialized);
        }
    }
}










  
