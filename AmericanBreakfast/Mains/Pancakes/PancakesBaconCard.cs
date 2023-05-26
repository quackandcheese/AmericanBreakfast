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
    class PancakeBaconCard : CustomDish
    {
        public override string UniqueNameID => "PancakeBaconCard";
        public override DishType Type => DishType.Extra;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
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
                Ingredient = Refs.BaconPortion,
                MenuItem = Refs.PlatedPancakes
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Pork
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Refs.Cook,
            Refs.Chop
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Chop pork, and cook to make bacon. Portion, and add to plated pancakes." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Pancakes & Bacon", "Adds bacon as a pancake topping", "Smoked and served") )
        };
    }
}
