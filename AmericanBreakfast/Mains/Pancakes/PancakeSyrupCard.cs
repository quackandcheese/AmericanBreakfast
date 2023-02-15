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
    class PancakeSyrupCard : CustomDish
    {
        public override string UniqueNameID => "PancakeSyrupCard";
        public override DishType Type => DishType.Extra;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.None;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;

        public override List<Unlock> HardcodedRequirements => new()
        {
            Refs.AmericanBreakfastDish
        };

        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                Ingredient = Refs.Syrup,
                MenuItem = Refs.PlatedPancakes
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.SyrupBottle
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Use with plated pancakes to add syrup, then serve." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Pancake Syrup", "Adds maple syrup as a pancake topping", "Simple yet delicious") )
        };
    }
}
