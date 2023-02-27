using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class CookedTomatoSpinachOmelette : CustomItemGroup<CookedTomatoSpinachOmeletteItemGroupView>
    {
        public override string UniqueNameID => "Cooked Tomato Spinach Omelette";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Cooked Tomato Spinach Omelette");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 0.5f,
                Process = Refs.Knead,
                Result = Refs.TomatoSpinachOmelette
            }
        };

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 3,
                Min = 3,
                Items = new List<Item>()
                {
                    Refs.CookedOmelette,
                    Refs.ChoppedTomato,
                    Refs.ChoppedLettuce  //Refs.ChoppedSpinach
                }
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var parent = Prefab.GetChild("Tomato Spinach.001");
            var tomato = parent.GetChildFromPath("Tomato - Chopped/Tomato Sliced");

            parent.ApplyMaterialToChild("Chopped Spinach.001/Spinaches.002", "Cooked Broccoli", "Lettuce");
            tomato.ApplyMaterialToChild("Liquid", "Tomato Flesh");
            tomato.ApplyMaterialToChild("Liquid.001", "Tomato Flesh 2");
            tomato.ApplyMaterialToChild("Skin", "Tomato");

            Prefab.ApplyMaterialToChild("Omelette.001", "Bread", "Egg - Yolk");

            Prefab.GetComponent<CookedTomatoSpinachOmeletteItemGroupView>()?.Setup(Prefab);
        }
    }


    public class CookedTomatoSpinachOmeletteItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Tomato Spinach.001/Tomato - Chopped"),
                    Item = Refs.ChoppedTomato
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Tomato Spinach.001/Chopped Spinach.001"),
                    Item = Refs.ChoppedLettuce  //Refs.ChoppedSpinach
                }
            };
        }
    }
}
