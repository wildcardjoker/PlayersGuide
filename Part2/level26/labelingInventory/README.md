# Labeling Inventory

You realise that your inventory items are not easy to sort through. If you could make it easy to label all of your inventory items, it would be easier to know what items you have in your pack.

Modify your inventory program from the previous level as described below.

## Objectives

- Override the existing `ToString` method (from the `object` base class) on all of your inventory item subclasses to give them a name. For example `new Rope().ToString()` should return "`Rope`".
- Override `ToString` on the `Pack` class to display the contents of the pack. If a pack contains water, rope, and two arrows, then calling `ToString` on that `Pack` object could look like "`Pack containing Water Rope Arrow Arrow`".
- Before the user chooses the next item to add, display the pack's current contents via its new `ToString` method.
