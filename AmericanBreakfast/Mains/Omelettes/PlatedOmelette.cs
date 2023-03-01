using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Transforms;

namespace KitchenAmericanBreakfast.Mains
{
    class PlatedOmelette : CustomItemGroup<PlatedOmelettesItemGroupView>
    {
        public override string UniqueNameID => "Plated Omelette";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Plated Omelette");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemValue ItemValue => ItemValue.Large;
        public override Item DisposesTo => Refs.Plate;
        public override Item DirtiesTo => Refs.DirtyPlate;
        public override bool CanContainSide => true;

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.Plate
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.TomatoSpinachOmelette
                }
            }/*,
            new ItemSet()
            {
                Max = 1,
                Min = 0,
                RequiresUnlock = true,
                Items = new List<Item>()
                {
                    // TOPPINGS
                }
            }*/
        };


        public override void OnRegister(GameDataObject gameDataObject)
        {
            var omelette = Prefab.GetChild("Tomato Spinach Omelette");
            var tomatoes = omelette.GetChildFromPath("Tomato - Chopped/Tomato Sliced");
            var plate = Prefab.GetChildFromPath("Plate/Plate");


            //Tomato Spinach
            omelette.ApplyMaterialToChild("Spinaches", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Spinach\""].name, CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Spinach Stem\""].name);
            tomatoes.ApplyMaterialToChild("Liquid", "Tomato Flesh");
            tomatoes.ApplyMaterialToChild("Liquid.001", "Tomato Flesh 2");
            tomatoes.ApplyMaterialToChild("Skin", "Tomato");

            omelette.ApplyMaterialToChild("Folded Omelette", "Bread", "Egg - Yolk");


            //Bacon Cheese
            var bcOmelette = Prefab.GetChild("Bacon Cheese Omelette");
            var baconCheese = bcOmelette.GetChildFromPath("Bacon Cheese");

            baconCheese.ApplyMaterialToChild("Bacon Portion.002", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon Fat\""].name, CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon\""].name); ;
            baconCheese.ApplyMaterialToChild("Cheese", "Cheese - Default");

            bcOmelette.ApplyMaterialToChild("Folded Omelette", "Bread", "Egg - Yolk");


            //Mushroom Onion
            var moOmelette = Prefab.GetChild("Mushroom Onion Omelette");
            moOmelette.ApplyMaterialToChild("mushroomHalf.016", "Mushroom Dark", "Mushroom Light");

            moOmelette.GetChildFromPath("Onions").ApplyMaterialToChildren("Circle", "Onion - Flesh", "Onion");

            moOmelette.ApplyMaterialToChild("Folded Omelette", "Bread", "Egg - Yolk");


            //Plate
            plate.ApplyMaterialToChild("Cylinder", "Plate", "Plate - Ring");


            Prefab.GetComponent<PlatedOmelettesItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }
    }


    public class PlatedOmelettesItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Plate"),
                    Item = Refs.Plate
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Tomato Spinach Omelette"),
                    Item = Refs.TomatoSpinachOmelette
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Bacon Cheese Omelette"),
                    Item = Refs.BaconCheeseOmelette
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Mushroom Onion Omelette"),
                    Item = Refs.MushroomOnionOmelette
                }
            };

            ComponentLabels = new()
            {
                new ()
                {
                    Text = "ToSp",
                    Item = Refs.TomatoSpinachOmelette
                },
                new ()
                {
                    Text = "BaCh",
                    Item = Refs.BaconCheeseOmelette
                },
                new ()
                {
                    Text = "MuO",
                    Item = Refs.MushroomOnionOmelette
                }
            };
        }
    }
}
