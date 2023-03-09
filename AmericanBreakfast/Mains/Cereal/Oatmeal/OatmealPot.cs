using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KitchenData.ItemGroup;
using UnityEngine;
using IngredientLib.Util;
using static KitchenAmericanBreakfast.Utils.MaterialHelper;

namespace KitchenAmericanBreakfast.Mains
{
    class OatmealPot : CustomItemGroup<OatmealPotItemGroupView>
    {
        public override string UniqueNameID => "Oatmeal Pot";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Oatmeal Pot");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item DisposesTo => Refs.Pot;

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.Pot
                }
            },            
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.Oats
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.Water
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess()
            {
                Duration = 10f,
                Process = Refs.Cook,
                Result = Refs.OatmealPotCooked
            }
        };


        public override void OnRegister(GameDataObject gameDataObject)
        {
            SetupPot(Prefab);

            var oatmeal = Prefab.GetChild("Oats");
            oatmeal.ApplyMaterialToChild("Oats", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Oat Grain\""].name);
            oatmeal.ApplyMaterialToChild("Mound", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Oat Mound\""].name);

            Prefab.GetChild("Water").ApplyMaterialToChild("Water", "Water");


            Prefab.GetComponent<OatmealPotItemGroupView>()?.Setup(Prefab);


            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }
    }
    public class OatmealPotItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Oats"),
                    Item = Refs.Oats
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Pot"),
                    Item = Refs.Pot
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Water"),
                    Item = Refs.Water
                }
            };

            ComponentLabels = new()
            {
                new ()
                {
                    Text = "Oa",
                    Item = Refs.Oats
                }
            };
        }
    }
}
