using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class OatmealCinnamon : CustomDish
    {
        public override string UniqueNameID => "Oatmeal Cinnamon Card";
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
            Refs.OatmealDish
        };

        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                Ingredient = Refs.Cinnamon,
                MenuItem = Refs.PlatedOatmeal
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Cinnamon
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Add cinnamon to portion of oatmeal" }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Cinnamon Oatmeal", "Adds cinnamon as an oatmeal topping", "Is there anything that doesn’t taste better with cinnamon?") )
        };
    }
}
