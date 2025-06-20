﻿using KitchenData;
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
    class WafflesChickenCard : CustomDish
    {
        public override string UniqueNameID => "WafflesChickenCard";
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
            Refs.WafflesDish
        };

        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                Ingredient = Refs.CookedDrumstick,
                MenuItem = Refs.PlatedWaffles
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Drumstick
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Refs.Cook
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Cook and add to plated waffle. Do not remove the bone." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Chicken & Waffles", "Adds chicken as a waffle topping", "A southern classic") )
        };
    }
}
