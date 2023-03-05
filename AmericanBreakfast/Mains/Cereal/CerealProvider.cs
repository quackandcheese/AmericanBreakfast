using Kitchen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class CerealProvider : CustomAppliance
    {
        public override string UniqueNameID => "Cereal Provider";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Cereal Provider");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;


        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateApplianceInfo("Cereal", "Provides three different cereals", new(), new()) )
        };

        public override List<IApplianceProperty> Properties => new()
        {
            GetCItemProvider(Refs.Cornflakes.ID, 0, 0, false, false, true, false, false, false, false),
            new CVariableProvider()
            {
                Current = 0,
                Provide1 = Refs.Cornflakes.ID,
                Provide2 = Refs.Qwix.ID,
                Provide3 = Refs.Quackos.ID
            }
        };


        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.AddComponent<VariableProviderView>().Animator = Prefab.GetComponent<Animator>();

            var holdTransform = Prefab.GetChildFromPath("HoldPoint").transform;
            var holdPoint = Prefab.AddComponent<HoldPointContainer>();
            holdPoint.HoldPoint = holdTransform; 

            // Visuals
            var iceCream = Prefab.GetChild("IceCream");
            var counter = iceCream.GetChild("Base_L_Counter.blend");

            iceCream.ApplyMaterialToChild("Top_L_Counter.blend", "Wood - Default");

            counter.ApplyMaterial("Wood - Default", "Wood 4 - Painted", "Wood 4 - Painted");
            counter.ApplyMaterialToChild("Handle_L_Counter.blend", "Knob");


            iceCream.ApplyMaterialToChild("Cube", "Metal");
            iceCream.ApplyMaterialToChild("Lid 3", "Door Glass", "Metal Dark");
            iceCream.ApplyMaterialToChild("Lid 2", "Door Glass", "Metal Dark");
            iceCream.ApplyMaterialToChild("Lid 1", "Metal Dark", "Door Glass");

            var cheerios = MaterialHelper.GetMaterialArray("Sack");
            iceCream.ApplyMaterialToChild("Icecream 1", cheerios);
            iceCream.GetChildFromPath("Icecream 1/Quackos").ApplyMaterialToChildren("Quackos", cheerios);

            var qwix = MaterialHelper.GetMaterialArray("Qwix", "Strawberry", "Egg - Yolk", "Lettuce", "Sea");
            iceCream.ApplyMaterialToChild("Icecream 2", qwix);
            iceCream.GetChild("Icecream 2").ApplyMaterialToChildren("Qwix", qwix);

            var cornflakes = MaterialHelper.GetMaterialArray("Sweetcorn - Cooked");
            iceCream.ApplyMaterialToChild("Icecream 3", cornflakes);
            iceCream.GetChildFromPath("Icecream 3/Cornflakes").ApplyMaterialToChildren("Cornflakes", cornflakes);

        }
    }
}
