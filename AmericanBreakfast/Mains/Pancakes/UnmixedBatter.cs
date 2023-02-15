using Kitchen;
using KitchenAmericanBreakfast.Utils;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KitchenAmericanBreakfast.Mains
{
    internal class UnmixedBatter : CustomItemGroup<UnmixedBatterItemGroupView>
    {
        public override string UniqueNameID => "UnmixedBatter";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("UnmixedBatter");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override string ColourBlindTag => "Ba";

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.Flour
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.CrackedEgg
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.Sugar
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 0.75f,
                Process = Refs.Knead,
                Result = Refs.Batter
            }
        };


        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Bowl", "Metal Dark");
            Prefab.ApplyMaterialToChild("Flour", "Flour");
            Prefab.ApplyMaterialToChild("Sugar", "Sugar");
            Prefab.ApplyMaterialToChild("Egg", "Egg - White", "Egg - Yolk");

            Prefab.GetComponent<UnmixedBatterItemGroupView>()?.Setup(Prefab);
        }
    }
    public class UnmixedBatterItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab) =>
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Flour"),
                    Item = Refs.Flour
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Egg"),
                    Item = Refs.CrackedEgg
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Sugar"),
                    Item = Refs.Sugar
                }
            };
    }
}
