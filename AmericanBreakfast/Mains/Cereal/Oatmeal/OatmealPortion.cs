using KitchenAmericanBreakfast.Utils;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.UI;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static KitchenAmericanBreakfast.Utils.MaterialHelper;

namespace KitchenAmericanBreakfast.Mains
{
    class OatmealPortion : CustomItem
    {
        public override string UniqueNameID => "Oatmeal Portion";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Oatmeal Portion");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override string ColourBlindTag => "Oa";

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Oats", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Oat Grain\""].name);
            Prefab.ApplyMaterialToChild("Water", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Oat Mound\""].name);
            Prefab.ApplyMaterialToChild("Bowl", "Plate");            
        }
    }

    class Oatmeal : CustomItemGroup<OatmealItemGroupView>
    {
        public override string UniqueNameID => "Oatmeal";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Oatmeal");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
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
            Prefab.ApplyMaterialToChild("Oats", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Oat Grain\""].name);
            Prefab.ApplyMaterialToChild("Water", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Oat Mound\""].name);
            Prefab.ApplyMaterialToChild("Bowl", "Plate");
            Prefab.GetChild("Blueberries").ApplyMaterialToChildren("blueberry", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Blueberry\""].name, CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Blueberry 2\""].name);
            Prefab.ApplyMaterialToChild("Cinnamon", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Cinnamon\""].name);

            Prefab.GetComponent<OatmealItemGroupView>()?.Setup(Prefab);
        }
    }

    public class OatmealItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Blueberries"),
                    Item = Refs.Blueberries
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cinnamon"),
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
