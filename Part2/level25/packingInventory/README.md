# Packing Inventory

You know you have a long, dangerous journey ahead of you to travel to and repair the Fountain of Objects. You decide to build some classes and objects to manage your inventory to prepare for the trip.

You decide to create a `Pack` class to help in holding your items. Each pack has three limits: the total number of items it can hold; the weight if can carry, and the volume it can hold. Each item has a weight and volume, and you must not overload a pack by adding too many items, too much weight, or too much volume.

There are many item types that you might add to your inventory, each their own class in the inventory system.

1. An `arrow` has a weight of `0.1` and a volume of `0.05`.
2. A `bow` has a weight of `1` and a volume of `4`.
3. `Rope` has a weight of `1` and a volume of `1.5`.
4. `Water` has a weight of `2` and a volume of `3`.
5. `Food rations` have a weight of `1` and a volume of `0.5`.
6. A `sword` has a weight of `5` and a volume of `3`.

## Objectives

- Create an `InventoryItem` class that represents any of the different item types. This class must represent the item's weight and volume, which it needs at creation time (constructor).
- Create derived classes for each of the types of items above. Each class should has the correct weight and volume to the base class constructor but should be creatable themselves with a parameterless constructor (for example, `new Rope()` or `new Sword()`).
- Build a `Pack` class that can store an array of items. The total number of items, the maximum weight, and the maximum volume are provided at creation time and cannot change afterward.
- Make a `public bool Add(InventoryItem item)` method to `Pack` that allows you to add items of any type to the `pack`'s contents. This method should fail (return `false` and not modify the pack's fields) if adding the item would cause it to exceed the pack's item, weight, or volume limits.
- Add properties to `Pack` that allow it to report the current item count, weight, and volume, and the limits of each.
- Create a program that creates a new pack and then allow the user to add (or attempt to add) items chosen from a menu.
