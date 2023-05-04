using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class PlatedCereal : CustomItemGroup<PlatedCerealItemGroupView>
    {
        public override string UniqueNameID => "Plated Cereal";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Plated Cereal");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemValue ItemValue => ItemValue.Small;
        public override Item DisposesTo => Refs.Plate;
        public override Item DirtiesTo => Refs.DirtyPlate;
        public override bool CanContainSide => true;

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = false,
                Items = new List<Item>()
                {
                    Refs.Plate
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = false,
                Items = new List<Item>()
                {
                    Refs.SplitMilk
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.Quackos,
                    Refs.Qwix,
                    Refs.Cornflakes
                }
            }
        };


        public override void OnRegister(GameDataObject gameDataObject)
        {
            //Plate
            var plate = Prefab.GetChild("Plate/Plate");           
            plate.ApplyMaterialToChild("Cylinder", "Plate", "Plate - Ring");

            //Cereal
            var cereal = Prefab.GetChild("Cereal");

            cereal.GetChild("Bowl").ApplyMaterialToChild("Small Bowl.001", "Plate");

            cereal.ApplyMaterialToChild("Milk", "Coffee Cup");

            cereal.GetChild("Cornflakes").ApplyMaterialToChildren("Cornflakes", "Sweetcorn - Cooked");
            cereal.ApplyMaterialToChild("Qwix", "Strawberry", "Egg - Yolk", "Lettuce", "Sea");
            cereal.GetChild("Quackos").ApplyMaterialToChildren("Quackos", "Sack");


            Prefab.GetComponent<PlatedCerealItemGroupView>()?.Setup(Prefab);
        }
    }


    public class PlatedCerealItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cereal/Quackos"),
                    Item = Refs.Quackos
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cereal/Qwix"),
                    Item = Refs.Qwix
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cereal/Cornflakes"),
                    Item = Refs.Cornflakes
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cereal/Milk"),
                    Item = Refs.SplitMilk
                }
            };

            ComponentLabels = new()
            {
                new ()
                {
                    Text = "Ch",
                    Item = Refs.Quackos
                },
                new ()
                {
                    Text = "Tr",
                    Item = Refs.Qwix
                },
                new ()
                {
                    Text = "Co",
                    Item = Refs.Cornflakes
                }
            };
        }
    }
}
