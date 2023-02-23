var original       = new Sword(SourceMaterial.Iron, AugmentationGemstone.None, 10, 4);
var augmentedSword = original with {Gemstone = AugmentationGemstone.Diamond};
var superSword     = original with {Gemstone = AugmentationGemstone.Bitstone, Length = 15, Material = SourceMaterial.Binarium};

Console.WriteLine(original);
Console.WriteLine(augmentedSword);
Console.WriteLine(superSword);

internal record Sword(SourceMaterial Material, AugmentationGemstone Gemstone, int Length, int Crossguard);

internal enum SourceMaterial
{
    Binarium,
    Bronze,
    Iron,
    Steel,
    Wood
}

internal enum AugmentationGemstone
{
    None,
    Amber,
    Bitstone,
    Diamond,
    Emerald,
    Sapphire
}