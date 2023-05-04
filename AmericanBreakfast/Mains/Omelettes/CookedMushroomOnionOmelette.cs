using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class CookedMushroomOnionOmelette : CustomItemGroup<CookedMushroomOnionOmeletteItemGroupView>
    {
        public override string UniqueNameID => "Cooked Mushroom Onion Omelette";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Cooked Mushroom Onion Omelette");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 0.5f,
                Process = Refs.Knead,
                Result = Refs.MushroomOnionOmelette
            }
        };

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.CookedOmelette
                }
            },
            new ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    Refs.ChoppedMushroom,
                    Refs.ChoppedOnion
                }
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChild("mushroomHalf.017", "Mushroom Dark", "Mushroom Light");

            Prefab.GetChild("Onion - Chopped.008/Onion - Chopped.009").ApplyMaterialToChildren("Circle", "Onion - Flesh", "Onion");

            Prefab.ApplyMaterialToChild("Omelette.001", "Bread", "Egg - Yolk");


            Prefab.GetComponent<CookedMushroomOnionOmeletteItemGroupView>()?.Setup(Prefab);
        }
    }


    public class CookedMushroomOnionOmeletteItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "mushroomHalf.017"),
                    Item = Refs.ChoppedMushroom
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Onion - Chopped.008"),
                    Item = Refs.ChoppedOnion
                }
            };

            ComponentLabels = new()
            {
                new()
                {
                    Item = Refs.ChoppedMushroom,
                    Text = "Mu"
                },
                new()
                {
                    Item = Refs.ChoppedOnion,
                    Text = "O"
                }
            };
        }
    }
}
