using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class OatmealBlueberries : CustomDish
    {
        public override string UniqueNameID => "Oatmeal Blueberries Card";
        public override DishType Type => DishType.Extra;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;
        public override int Difficulty => 1;

        public override List<Unlock> HardcodedRequirements => new()
        {
            Refs.OatmealDish
        };

        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                Ingredient = Refs.Blueberries,
                MenuItem = Refs.PlatedOatmeal
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Blueberries
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Add blueberries to portion of oatmeal" }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Blueberry Oatmeal", "Adds blueberries as an oatmeal topping", "Sweet but tangy flavor that’s hard to beat.") )
        };
    }
}
