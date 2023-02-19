using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Sides
{
    class ScrambledEggWokUncooked : CustomItemGroup<ScrambledEggWokItemGroupView>
    {
        public override string UniqueNameID => "ScrambledEggWokUncooked";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ScrambledEggWokUncooked");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item DisposesTo => Refs.Wok;

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess 
            {
                Duration = 2,
                Process = Refs.Cook,
                Result = Refs.ScrambledEggWokCooked
            }
        };

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.Wok
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.MixedEgg
                }
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var wok = Prefab.GetChild("Wok");

            wok.ApplyMaterialToChild("Cylinder", "Metal Black");
            wok.ApplyMaterialToChild("Cylinder.003", "Wood 5 - Grey");

            Prefab.ApplyMaterialToChild("MixedEgg", "Egg - Yolk");


            Prefab.GetComponent<ScrambledEggWokItemGroupView>()?.Setup(Prefab);
        }
    }


    public class ScrambledEggWokItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Wok"),
                    Item = Refs.Wok
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "MixedEgg"),
                    Item = Refs.MixedEgg
                }
            };
        }
    }
}
