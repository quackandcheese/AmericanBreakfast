﻿using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenAmericanBreakfast.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KitchenAmericanBreakfast.Mains
{
    class Pancake : CustomItem
    {
        public override string UniqueNameID => "Pancake";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Pancake");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 5.5f,
                Process = Refs.Cook,
                IsBad = true,
                Result = Refs.Burnt
            }
        };

        public override void OnRegister(Item item)
        {
            Prefab.ApplyMaterialToChild("Pancake.001", "Raw Pastry", "Onion");
        }
    }
}
