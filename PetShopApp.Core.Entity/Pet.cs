﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime BirthDay { get; set; }

        public DateTime SoldDate { get; set; }

        public string Color { get; set; }

        public Owner owner  { get; set; }

        public double Price { get; set; }
    }
}
