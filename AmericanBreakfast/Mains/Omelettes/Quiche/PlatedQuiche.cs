using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KitchenAmericanBreakfast.Utils.MaterialHelper;

namespace KitchenAmericanBreakfast.Mains
{
    class PlatedQuiche : CustomItemGroup<PlatedQuicheItemGroupView>
    {
        public override string UniqueNameID => "Plated Quiche";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Plated Quiche");
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
                    Refs.CookedQuiche
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
            var quiche = Prefab.GetChild("Cooked Quiche");
            for (int i = 0; i <= 3; i++)
            {
                MaterialUtils.ApplyMaterial(quiche, $"Slice {i + 1}/Filling", new Material[] { MaterialUtils.GetExistingMaterial("Egg - Yolk") });
                MaterialUtils.ApplyMaterial(quiche, $"Slice {i + 1}/Slice", new Material[] { MaterialUtils.GetExistingMaterial("Cooked Pastry") });
            }

            quiche.ApplyMaterialToChild("Herbs", "Lettuce");

            //Plate
            SetupPlate(Prefab);


            Prefab.GetComponent<PlatedQuicheItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }
    }


    public class PlatedQuicheItemGroupView : ItemGroupView
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
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cooked Quiche"),
                    Item = Refs.CookedQuiche
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
