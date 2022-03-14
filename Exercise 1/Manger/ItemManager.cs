using Exercise_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_1.ItemsManager
{
    public class ItemManager
    {
        private static int  _nextId=1;

        private static readonly List<Item> Data = new List<Item>
        {
            new Item{Id=_nextId++,Name="C# is nice",ItemQuality=100,Quantity=200},
            new Item{Id=_nextId++,Name="C++ is perfect",ItemQuality=500,Quantity=300},
             new Item{Id=_nextId++,Name="C is good ",ItemQuality=50,Quantity=100},

        };

        public List<Item> GetAll(String substring,int minQuality,int quantity)
        {
            List<Item> result = new List<Item>(Data);
            if(substring !=null)
            {
                result = result.FindAll(item => item.Name.Contains(substring, StringComparison.OrdinalIgnoreCase));
            }
            if(minQuality != 0)
            {
                result = result.FindAll(item => item.ItemQuality >= minQuality);
            }
            if (minQuality!=0)
            {
                result = result.FindAll(item => item.Quantity >= quantity);
            }
            return result;
        }

        public List<Item> getAllBetweenQaulity(int minQuality, int maxQuality)
        {

            List<Item> result = new List<Item>(Data);
            result = result.FindAll(item => item.ItemQuality >= minQuality && item.ItemQuality <= maxQuality);
            return result;
        }
        

        public Item GetById(int Id)
        {
            return Data.Find(item => item.Id == Id);
        }

        public Item Add(Item newItem)
        {
            newItem.Id = _nextId++;
            Data.Add(newItem);
            return newItem;
        }
        public Item Delete(int Id)
        {
            Item item = Data.Find(item1 => item1.Id == Id);
            if (item == null) return null;
            Data.Remove(item);
            return item;
        }
        public Item Update(int id,Item updates)
        {
            Item item = Data.Find(item1 => item1.Id == id);
            if (item == null) return null;
            item.Name = updates.Name;
            item.ItemQuality = updates.ItemQuality;
            item.Quantity = updates.Quantity;
            return item;
        
        


        }




           

    }
}
