using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class UncookedQuiche : CustomItemGroup<UncookedQuicheItemGroupView>
    {
        public override string UniqueNameID => "Uncooked Quiche";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Uncooked Quiche");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        //public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.CookedPieCrust
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.CrackedEgg,
                    Refs.MixedEgg
                }
            }/*,
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.Sugar
                }
            }*/
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 3f,
                Process = Refs.Cook,
                Result = Refs.CookedQuiche
            }
        };


        public override void OnRegister(GameDataObject gameDataObject) 
        {
            var crust = Prefab.GetChild("Pie Cooked");

            crust.ApplyMaterialToChild("Crust", "Cooked Pastry");
            crust.ApplyMaterialToChild("Lattice", "Cooked Pastry");
            crust.ApplyMaterialToChild("Dish", "Plate");

            Prefab.ApplyMaterialToChild("Egg", "Egg - White", "Egg - Yolk");
            Prefab.ApplyMaterialToChild("Mixed Egg", "Egg - Yolk");

            Prefab.GetComponent<UncookedQuicheItemGroupView>()?.Setup(Prefab);
        }
    }
    public class UncookedQuicheItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new() 
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Egg"),
                    Item = Refs.CrackedEgg
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Mixed Egg"),
                    Item = Refs.MixedEgg
                }
            };
            ComponentLabels = new()
            {
                new ()
                {
                    Text = "E",
                    Item = Refs.CrackedEgg
                },
                new ()
                {
                    Text = "E",
                    Item = Refs.MixedEgg
                }
            };
        }
    }
}
