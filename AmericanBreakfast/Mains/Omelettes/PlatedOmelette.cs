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

            //Visuals
            omelette.ApplyMaterialToChild("Spinaches", "Cooked Broccoli", "Lettuce");
            tomatoes.ApplyMaterialToChild("Liquid", "Tomato Flesh");
            tomatoes.ApplyMaterialToChild("Liquid.001", "Tomato Flesh 2");
            tomatoes.ApplyMaterialToChild("Skin", "Tomato");

            omelette.ApplyMaterialToChild("Folded Omelette", "Bread", "Egg - Yolk");


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
                }
            };

            ComponentLabels = new()
            {
                new ()
                {
                    Text = "ToSp",
                    Item = Refs.TomatoSpinachOmelette
                }
            };
        }
    }
}
