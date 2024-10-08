﻿using KitchenLib.Preferences;

namespace KitchenAmericanBreakfast.Mains
{
    class AmericanBreakfastDish : CustomDish
    {
        public override string UniqueNameID => "American Breakfast Dish";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("AmericanBreakfastIcon");
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;
        public override bool IsAvailableAsLobbyOption => true;
        public override int Difficulty => 2;

        public override List<string> StartingNameSet => new List<string>
        {
            "Flippin' Tasty",
            "Flapjack Fantasy",
            "Batter Up",
            "Scrambled Shenanigans",
            "Flapjack Factory",
            "Eggcellent Eats",
            "The Pancake Pitstop",
            "Pancake Party",
            "Pancake Paradise",
            "Pancake Palace"
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
            { Locale.English, "Combine flour, cracked (or mixed) egg, sugar, and mix together. Portion, cook, plate, and serve. Customers can order 1-2 pancakes in a stack." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("American Breakfast", "Adds pancakes as a main", "Spontaneous stacks") )
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var pancake = DisplayPrefab.GetChild("Pancakes");
            var plate = DisplayPrefab.GetChild("Plate/Plate.001");

            //Visuals

            pancake.ApplyMaterialToChildren("Pancake", "Raw Pastry", "Onion");

            pancake.GetChild("Top Pancake").ApplyMaterialToChild("Butter - Slice.002", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Butter\""].name);
            pancake.GetChild("Middle Pancake").ApplyMaterialToChild("Butter - Slice.001", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Butter\""].name);
            pancake.GetChild("Bottom Pancake").ApplyMaterialToChild("Butter - Slice", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Butter\""].name);

            DisplayPrefab.ApplyMaterialToChild("Bacon", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon Fat\""].name, CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon\""].name);

            plate.ApplyMaterialToChild("Cylinder", "Plate", "Plate - Ring");

            DisplayPrefab.GetChild("Syrup").ApplyMaterialToChild("Plane.002", "Cooked Batter");
            DisplayPrefab.GetChild("ScrambledEggsSide").ApplyMaterialToChild("Scrambled Eggs.001", "Egg - Yolk", "Cooked Pastry");
        }
    }
}
