using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class Cereal : CustomItemGroup<CerealItemGroupView>
    {
        public override string UniqueNameID => "Cereal";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Cereal");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Large;

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = false,
                Items = new List<Item>()
                {
                    Refs.Milk
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
            Prefab.GetChild("Bowl").ApplyMaterialToChild("Small Bowl.001", "Plate");

            Prefab.ApplyMaterialToChild("Milk", "Coffee Cup");

            Prefab.GetChild("Cornflakes").ApplyMaterialToChildren("Cornflakes", "Sweetcorn - Cooked");
            Prefab.ApplyMaterialToChild("Qwix", "Strawberry", "Egg - Yolk", "Lettuce", "Sea");
            Prefab.GetChild("Quackos").ApplyMaterialToChildren("Quackos", "Sack");

            Prefab.GetComponent<CerealItemGroupView>()?.Setup(Prefab);
        }
    }


    public class CerealItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Quackos"),
                    Item = Refs.Quackos
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Qwix"),
                    Item = Refs.Qwix
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cornflakes"),
                    Item = Refs.Cornflakes
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Milk"),
                    Item = Refs.Milk
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
