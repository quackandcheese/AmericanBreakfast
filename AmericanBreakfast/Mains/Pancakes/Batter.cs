using KitchenData;
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
    class Batter : CustomItem
    {
        public override string UniqueNameID => "Batter";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Batter");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override Item SplitSubItem => Refs.BatterPortion;
        public override List<Item> SplitDepletedItems => new() { Refs.BatterPortion };
        public override int SplitCount => 1;
        public override float SplitSpeed => 3.0f;

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 3,
                Process = Refs.CookWaffle,
                Result = Refs.Waffle
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Bowl.001", "Metal Dark");
            Prefab.ApplyMaterialToChild("Flour.001", "Raw Pastry");
        }
    }
}
