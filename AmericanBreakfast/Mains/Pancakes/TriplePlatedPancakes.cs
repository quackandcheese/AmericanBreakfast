

namespace KitchenAmericanBreakfast.Mains
{
    class TriplePlatedPancakes : PlatedPancakes
    {
        public override string UniqueNameID => "TriplePlatedPancakes";
        public override ItemValue ItemValue => ItemValue.Medium;
        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 4,
                Min = 4,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.Plate,
                    Refs.Pancake,
                    Refs.Pancake,
                    Refs.Pancake
                }
            },
            new ItemSet()
            {
                Max = 2,
                Min = 0,
                RequiresUnlock = true,
                Items = new List<Item>()
                {
                    //Refs.Pancake,
                    //Refs.Syrup,
                    Refs.BaconPortion,
                    Refs.ButterSlice
                }
            }
        };
    }
}

