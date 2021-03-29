﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class Good
    {
        public Good()
        {
            GoodEntries = new HashSet<GoodEntry>();
            Warehouses = new HashSet<Warehouse>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int MinimomStak { get; set; }
        public int CategoryId { get; set; }
        public Category  category { get; set; }
        public HashSet<GoodEntry>  GoodEntries { get; set; }
        public HashSet<Warehouse> Warehouses { get; set; }

    }
}