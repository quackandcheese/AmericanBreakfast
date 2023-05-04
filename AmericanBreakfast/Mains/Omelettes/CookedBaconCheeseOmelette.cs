using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class CookedBaconCheeseOmelette : CustomItemGroup<CookedBaconCheeseOmeletteItemGroupView>
    {
        public override string UniqueNameID => "Cooked Bacon Cheese Omelette";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Cooked Bacon Cheese Omelette");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 0.5f,
                Process = Refs.Knead,
                Result = Refs.BaconCheeseOmelette
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
                    Refs.BaconPortion,
                    Refs.ChoppedCheese
                }
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {

            Prefab.ApplyMaterialToChild("Bacon Portion.001", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon Fat\""].name, CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon\""].name);

            Prefab.GetChild("Cheese - Grated").ApplyMaterialToChildren("Potato - Chopped", "Cheese - Default");

            Prefab.ApplyMaterialToChild("Omelette.001", "Bread", "Egg - Yolk");

            Prefab.GetComponent<CookedBaconCheeseOmeletteItemGroupView>()?.Setup(Prefab);
        }
    }


    public class CookedBaconCheeseOmeletteItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Bacon Portion.001"),
                    Item = Refs.BaconPortion
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cheese - Grated"),
                    Item = Refs.ChoppedCheese
                }
            };


            ComponentLabels = new()
            {
                new()
                {
                    Item = Refs.BaconPortion,
                    Text = "Ba"
                },
                new()
                {
                    Item = Refs.ChoppedCheese,
                    Text = "Ch"
                }
            };
        }
    }
}

