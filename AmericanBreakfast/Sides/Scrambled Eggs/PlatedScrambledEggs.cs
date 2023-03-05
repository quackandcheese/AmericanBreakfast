/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class PlatedScrambledEggs : CustomItemGroup<PlatedScrambledEggsItemGroupView>
    {
        public override string UniqueNameID => "Plated Scrambled Eggs";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Plated Scrambled Eggs");
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
                Items = new List<Item>()
                {
                    Refs.Plate
                }
            },
            new ItemSet()
            {
                Max = 3,
                Min = 3,
                Items = new List<Item>()
                {
                    Refs.ScrambledEgg,
                    Refs.ScrambledEgg,
                    Refs.ScrambledEgg
                }
            }
        };


        public override void OnRegister(GameDataObject gameDataObject)
        {
            var plate = Prefab.GetChildFromPath("Plate/Plate");
            var scrambled = Prefab.GetChild("Scrambled Eggs");


            scrambled.ApplyMaterialToChildren("Slice", "Egg - Yolk", "Cooked Pastry");

            //Plate
            plate.ApplyMaterialToChild("Cylinder", "Plate", "Plate - Ring");


            Prefab.GetComponent<PlatedScrambledEggsItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }
    }


    public class PlatedScrambledEggsItemGroupView : ItemGroupView
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
                    Item = Refs.ScrambledEgg,
                    Objects = new List<GameObject>()
                    {
                        GameObjectUtils.GetChildObject(prefab, "Scrambled Eggs/Slice1"),
                        GameObjectUtils.GetChildObject(prefab, "Scrambled Eggs/Slice2"),
                        GameObjectUtils.GetChildObject(prefab, "Scrambled Eggs/Slice3"),
                    }
                } //
            };

            ComponentLabels = new()
            {
                new ()
                {
                    Text = "S",
                    Item = Refs.ScrambledEgg
                }
            };
        }
    }
}
*/