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
using IngredientLib.Util;

namespace KitchenAmericanBreakfast.Mains
{
    class AmericanBreakfastDish : CustomDish
    {
        public override string UniqueNameID => "American Breakfast Dish";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("AmericanBreakfast");
        public override GameObject IconPrefab => Mod.Bundle.LoadAsset<GameObject>("AmericanBreakfast");
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool IsAvailableAsLobbyOption => true;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;

        public override List<string> StartingNameSet => new List<string>
        {
            "Not Awful Waffles",
            "Waffle This Way",
            "Flippin' Tasty",
            "Slapjack Stackers",
            "Not Awful Waffles",
            "Waffle This Way",
            "Flippin' Tasty",
            "Slapjack Stackers",
            "Flapjack Fantasy"
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Refs.PlatedPancakes,
                Phase = MenuPhase.Main,
                Weight = 1
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
            Refs.Cook,
            Refs.Knead
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Combine flour, egg, and sugar. Cook, plate, and serve. Customers can order up to 3 pancakes in a stack." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("American Breakfast", "Adds Pancakes as a Main", "Spontaneous stacks") )
        };
    }
}
