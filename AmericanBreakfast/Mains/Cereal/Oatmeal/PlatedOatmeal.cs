using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KitchenAmericanBreakfast.Utils.MaterialHelper;

namespace KitchenAmericanBreakfast.Mains
{
    class PlatedOatmeal : CustomItemGroup<PlatedOatmealCookedItemView>
    {
        public override string UniqueNameID => "Plated Oatmeal";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Plated Oatmeal");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override Item DisposesTo => Refs.Plate;
        public override Item DirtiesTo => Refs.DirtyPlate;
        public override bool CanContainSide => true;

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.Plate,
                    Refs.OatmealPortion
                }
            },
            new ItemSet()
            {
                Max = 2,
                Min = 0,
                RequiresUnlock = true,
                Items = new List<Item>()
                {
                    Refs.Blueberries,
                    Refs.Cinnamon
                }
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var oatmeal = Prefab.GetChild("Oatmeal");
            oatmeal.ApplyMaterialToChild("Oats", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Oat Grain\""].name);
            oatmeal.ApplyMaterialToChild("Water", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Oat Mound\""].name);
            oatmeal.ApplyMaterialToChild("Bowl", "Plate");
            oatmeal.GetChild("Blueberries").ApplyMaterialToChildren("blueberry", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Blueberry\""].name, CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Blueberry 2\""].name);
            oatmeal.ApplyMaterialToChild("Cinnamon", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Cinnamon\""].name);

            SetupPlate(Prefab);

            Prefab.GetComponent<PlatedOatmealCookedItemView>()?.Setup(Prefab);


            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }
    }

    public class PlatedOatmealCookedItemView : ItemGroupView
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
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Oatmeal"),
                    Item = Refs.OatmealPortion
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Oatmeal/Blueberries"),
                    Item = Refs.Blueberries
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Oatmeal/Cinnamon"),
                    Item = Refs.Cinnamon
                }
            };

            ComponentLabels = new()
            {
                new ()
                {
                    Text = "Oa",
                    Item = Refs.OatmealPortion
                },
                new ()
                {
                    Text = "Bl",
                    Item = Refs.Blueberries
                },
                new ()
                {
                    Text = "Ci",
                    Item = Refs.Cinnamon
                }
            };
        }
    }
}
