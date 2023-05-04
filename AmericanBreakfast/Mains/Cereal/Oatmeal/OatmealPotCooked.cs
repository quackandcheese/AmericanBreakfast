using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static IngredientLib.Util.VisualEffectHelper;
using static KitchenAmericanBreakfast.Utils.MaterialHelper;

namespace KitchenAmericanBreakfast.Mains
{
    public class OatmealPotCookedItemView : PositionSplittableView
    {
        internal void Setup(GameObject prefab)
        {
            var fFullPosition = ReflectionUtils.GetField<PositionSplittableView>("FullPosition");
            fFullPosition.SetValue(this, new Vector3(0, 0.273f, 0));

            var fEmptyPosition = ReflectionUtils.GetField<PositionSplittableView>("EmptyPosition");
            fEmptyPosition.SetValue(this, new Vector3(0, 0.028f, 0));

            var fObjects = ReflectionUtils.GetField<PositionSplittableView>("Objects");
            fObjects.SetValue(this, new List<GameObject>()
            {
                prefab.GetChild("Oats")
            });
        }
    }

    public class OatmealPotCooked : CustomItem
    {
        public override string UniqueNameID => "Oatmeal Pot Cooked";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Oatmeal Pot Cooked");
        public override bool AllowSplitMerging => false;
        public override float SplitSpeed => 1f;
        public override int SplitCount => 5;
        public override Item SplitSubItem => Refs.OatmealPortion;
        public override List<Item> SplitDepletedItems => new() { Refs.Pot };
        public override Item DisposesTo => Refs.Pot;
        public override bool PreventExplicitSplit => false;
        public override string ColourBlindTag => "Oa";


        public override void OnRegister(GameDataObject gameDataObject)
        {
            SetupPot(Prefab);

            var oatmeal = Prefab.GetChild("Oats");
            oatmeal.ApplyMaterialToChild("Oats", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Oat Grain\""].name);
            oatmeal.ApplyMaterialToChild("Water", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Oat Mound\""].name);

            Prefab.GetChild("Steam").ApplyVisualEffect("Steam");


            if (!Prefab.HasComponent<OatmealPotCookedItemView>())
            {
                var view = Prefab.AddComponent<OatmealPotCookedItemView>();
                view.Setup(Prefab);
            }
        }
    }
}
