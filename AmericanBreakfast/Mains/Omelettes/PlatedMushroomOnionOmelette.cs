using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class PlatedMushroomOnionOmelette : CustomItemGroup<PlatedOmelettesItemGroupView>
    {
        public override string UniqueNameID => "Plated Mushroom Onion Omelette";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Plated Omelette");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemValue ItemValue => ItemValue.Large;
        public override Item DisposesTo => Refs.Plate;
        public override Item DirtiesTo => Refs.DirtyPlate;
        public override bool CanContainSide => true;

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.Plate
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.MushroomOnionOmelette
                }
            }
        };


        public override void OnRegister(GameDataObject gameDataObject)
        {
        }
    }
}
