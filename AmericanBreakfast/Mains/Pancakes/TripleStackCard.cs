using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Entities;
using KitchenAmericanBreakfast.Utils;
using KitchenAmericanBreakfast;

namespace KitchenAmericanBreakfast.Mains
{
    class TripleStackCard : CustomDish
    {
        public override string UniqueNameID => "TripleStackCard";
        public override DishType Type => DishType.Main;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("AmericanBreakfastIcon").AssignMaterialsByNames();
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;
        public override bool IsAvailableAsLobbyOption => true;
        public override int Difficulty => 3;
        public override List<Unlock> HardcodedRequirements => new()
        {
            Refs.AmericanBreakfastDish
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Refs.TriplePlatedPancakes,
                Phase = MenuPhase.Main,
                Weight = 0.5f
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Flour,
            Refs.Sugar,
            Refs.Egg,
            Refs.Plate
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Refs.Knead,
            Refs.Cook
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Add a third pancake to the stack" }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Triple Stack", "Customers can now order up to 3 pancakes in a stack", "The more the merrier!") )
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            DisplayPrefab.ApplyMaterialToChild("Butter", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Butter\""].name);
            DisplayPrefab.ApplyMaterialToChild("drumstick", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Cooked Drumstick\""].name, CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Cooked Drumstick Bone\""].name);
        }
    }
}
