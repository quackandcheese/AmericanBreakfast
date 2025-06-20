﻿
using ApplianceLib.Api.References;
using KitchenAmericanBreakfast.Sides;

namespace KitchenAmericanBreakfast
{
    internal class Refs
    {
        #region Vanilla References
        // Items
        public static Item Plate => Find<Item>(ItemReferences.Plate);
        public static Item DirtyPlate => Find<Item>(ItemReferences.PlateDirty);
        public static Item Wok => Find<Item>(ItemReferences.Wok);
        public static Item BurnedWok => Find<Item>(ItemReferences.WokBurned);
        public static Item Flour => Find<Item>(ItemReferences.Flour);
        public static Item Egg => Find<Item>(ItemReferences.Egg);
        public static Item Pot => Find<Item>(ItemReferences.Pot);
        public static Item Water => Find<Item>(ItemReferences.Water);
        public static Item CrackedEgg => Find<Item>(ItemReferences.EggCracked);
        public static Item Sugar => Find<Item>(ItemReferences.Sugar);
        public static Item Burnt => Find<Item>(ItemReferences.BurnedFood);
        public static Item Potato => Find<Item>(ItemReferences.Potato);
        public static Item ChoppedPotato => Find<Item>(ItemReferences.PotatoChopped);
        public static Item Tomato => Find<Item>(ItemReferences.Tomato);
        public static Item ChoppedTomato => Find<Item>(ItemReferences.TomatoChopped);
        public static Item Lettuce => Find<Item>(ItemReferences.Lettuce);
        public static Item ChoppedLettuce => Find<Item>(ItemReferences.LettuceChopped);
        public static Item Cheese => Find<Item>(ItemReferences.Cheese);
        public static Item ChoppedCheese => Find<Item>(ItemReferences.CheeseGrated);
        public static Item Mushroom => Find<Item>(ItemReferences.Mushroom);
        public static Item ChoppedMushroom => Find<Item>(ItemReferences.MushroomChopped);
        public static Item Onion => Find<Item>(ItemReferences.Onion);
        public static Item ChoppedOnion => Find<Item>(ItemReferences.OnionChopped);
        public static ItemGroup Mayo => Find<ItemGroup>(ItemReferences.Mayonnaise);
        public static Item OilIngredient => Find<Item>(ItemReferences.OilIngredient);
        public static Item CookedPieCrust => Find<Item>(ItemReferences.PieCrustCooked);
        public static Item Milk => Find<Item>(ItemReferences.Milk);

        // Processes
        public static Process Cook => Find<Process>(ProcessReferences.Cook);
        public static Process Chop => Find<Process>(ProcessReferences.Chop);
        public static Process Knead => Find<Process>(ProcessReferences.Knead);
        public static Process Oven => Find<Process>(ProcessReferences.RequireOven);

        // Appliances
        public static Appliance IceCreamProvider => Find<Appliance>(ApplianceReferences.SourceIceCream);
        #endregion

        #region IngredientLib References
        public static Item Pork => (Item)GetCustomGameDataObject(IngredientLib.References.GetIngredient("pork"))?.GameDataObject; //Find<Item>(IngredientLib.References.GetIngredient("pork"));
        public static Item Bacon => Find<Item>(IngredientLib.References.GetIngredient("bacon"));
        public static Item Blueberries => Find<Item>(IngredientLib.References.GetIngredient("blueberries"));
        public static Item Oats => Find<Item>(IngredientLib.References.GetIngredient("oats"));
        public static Item Cinnamon => Find<Item>(IngredientLib.References.GetIngredient("cinnamon"));
        public static Item Syrup => Find<Item>(IngredientLib.References.GetSplitIngredient("syrup"));
        public static Item SyrupBottle => Find<Item>(IngredientLib.References.GetIngredient("syrup"));
        public static Item EggNoodle => Find<Item>(IngredientLib.References.GetIngredient("egg dough"));
        public static Item UnmixedEggDough => Find<Item>(IngredientLib.References.GetIngredient("unmixed egg dough"));
        public static Item Butter => Find<Item>(IngredientLib.References.GetIngredient("butter"));
        public static Item ButterSlice => Find<Item>(IngredientLib.References.GetSplitIngredient("butter"));
        public static Item CookedDrumstick => Find<Item>(IngredientLib.References.GetIngredient("cooked drumstick"));
        public static Item Drumstick => Find<Item>(IngredientLib.References.GetIngredient("drumstick"));
        public static Item Spinach => Find<Item>(IngredientLib.References.GetIngredient("spinach"));
        public static Item ChoppedSpinach => Find<Item>(IngredientLib.References.GetIngredient("chopped spinach"));
        #endregion

        #region ApplianceLib References
        public static Item Cup => Find<Item>(ApplianceLibGDOs.Refs.Cup.ID);

        public static Appliance CupProvider => Find<Appliance>(ApplianceLibGDOs.Refs.CupProvider.ID);
        #endregion

        #region Modded References
        // Items
        public static Item Pancake => Find<Item, Pancake>();
        public static ItemGroup PlatedPancakes => Find<ItemGroup, PlatedPancakes>();
        public static ItemGroup TriplePlatedPancakes => Find<ItemGroup, TriplePlatedPancakes>();
        public static ItemGroup UnmixedBatter => Find<ItemGroup, UnmixedBatter>();
        public static Item Batter => Find<Item, Batter>();
        public static Item BatterPortion => Find<Item, BatterPortion>();
        public static Item BaconPortion => Find<Item, BaconPortion>();


        public static Item Waffle => Find<Item, Waffle>();
        public static ItemGroup PlatedWaffles => Find<ItemGroup, PlatedWaffles>();


        public static Item CookedOmelette => Find<Item, CookedOmelette>();
        public static Item TomatoSpinachOmelette => Find<Item, TomatoSpinachOmelette>();
        public static Item BaconCheeseOmelette => Find<Item, BaconCheeseOmelette>();
        public static Item MushroomOnionOmelette => Find<Item, MushroomOnionOmelette>();
        public static ItemGroup PlatedOmelette => Find<ItemGroup, PlatedOmelette>();
        public static ItemGroup PlatedBaconCheeseOmelette => Find<ItemGroup, PlatedBaconCheeseOmelette>();
        public static ItemGroup PlatedMushroomOnionOmelette => Find<ItemGroup, PlatedMushroomOnionOmelette>();


        public static Item Cereal => Find<Item, Cereal>();
        public static ItemGroup PlatedCereal => Find<ItemGroup, PlatedCereal>();
        public static Item Quackos => Find<Item, Quackos>();
        public static Item Qwix => Find<Item, Qwix>();
        public static Item Cornflakes => Find<Item, Cornflakes>();


        public static Item OatmealPortion => Find<Item, OatmealPortion>();
        public static ItemGroup Oatmeal => Find<ItemGroup, Oatmeal>();
        public static ItemGroup PlatedOatmeal => Find<ItemGroup, PlatedOatmeal>();
        public static ItemGroup OatmealPot => Find<ItemGroup, OatmealPot>();
        public static Item OatmealPotCooked => Find<Item, OatmealPotCooked>();


        public static ItemGroup PlatedQuiche => Find<ItemGroup, PlatedQuiche>();
        public static ItemGroup UncookedQuiche => Find<ItemGroup, UncookedQuiche>();
        public static Item CookedQuiche => Find<Item, CookedQuiche>();


        public static Item OrangeJuice => Find<Item, OrangeJuice>();
        public static ItemGroup OrangeJuiceGlass => Find<ItemGroup, OrangeJuiceGlass>();
        public static Item OrangeJuiceIngredient => Find<Item, OrangeJuiceIngredient>();


        public static Item MixedEgg => Find<Item, MixedEgg>();
        public static ItemGroup MixedEggMilk => Find<ItemGroup, MixedEggMilk>();
        public static Item ScrambledEgg => Find<Item, ScrambledEgg>();
        public static Item ScrambledEggWokUncooked => Find<Item, ScrambledEggWokUncooked>();
        public static Item ScrambledEggWokCooked => Find<Item, ScrambledEggWokCooked>();


        public static Item HashBrowns => Find<Item, HashBrowns>();
        public static Item HashBrownsWokUncooked => Find<Item, HashBrownsWokUncooked>();
        public static Item HashBrownsWokCooked => Find<Item, HashBrownsWokCooked>();
        // Cards
        public static Dish AmericanBreakfastDish => Find<Dish, AmericanBreakfastDish>();
        public static Dish TripleStackCard => Find<Dish, TripleStackCard>();
        public static Dish WafflesDish => Find<Dish, WafflesDish>();
        public static Dish MapleSyrupCard => Find<Dish, MapleSyrupCard>();
        public static Dish PancakeBaconCard => Find<Dish, PancakeBaconCard>();
        public static Dish ButterCard => Find<Dish, ButterCard>();
        public static Dish OmeletteDish => Find<Dish, OmeletteDish>();
        public static Dish BaconCheeseOmeletteDish => Find<Dish, BaconCheeseOmeletteDish>();
        public static Dish MushroomOnionOmeletteDish => Find<Dish, MushroomOnionOmeletteDish>();
        public static Dish CerealDish => Find<Dish, CerealDish>();
        public static Dish OatmealDish => Find<Dish, OatmealDish>();

        public static Dish WafflesChickenCard => Find<Dish, WafflesChickenCard>();
        public static Dish ScrambledEggsCard => Find<Dish, ScrambledEggsCard>();
        public static Dish OrangeJuiceCard => Find<Dish, OrangeJuiceCard>();

        // Appliances
        public static Appliance WaffleIron => Find<Appliance, WaffleIron>();
        public static Appliance WafflePress => Find<Appliance, WafflePress>();


        public static Appliance CerealProvider => Find<Appliance, CerealProvider>();


        public static Appliance OrangeJuiceProvider => Find<Appliance, OrangeJuiceProvider>();

        //Processes
        public static Process CookWaffle => Find<Process, CookWaffle>();
        #endregion



        internal static T Find<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id) ?? (T)GDOUtils.GetCustomGameDataObject(id)?.GameDataObject;
        }

        internal static T Find<T, C>() where T : GameDataObject where C : CustomGameDataObject
        {
            return GDOUtils.GetCastedGDO<T, C>();
        }

        internal static T Find<T>(string modName, string name) where T : GameDataObject
        {
            return GDOUtils.GetCastedGDO<T>(modName, name);
        }

        private static Appliance.ApplianceProcesses FindApplianceProcess<C>() where C : CustomSubProcess
        {
            ((CustomApplianceProccess)CustomSubProcess.GetSubProcess<C>()).Convert(out var process);
            return process;
        }
    }
}
