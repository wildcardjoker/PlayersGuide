# The Feud

On the Island of Namespaces, two families of ranchers are caretakers of the Medallion of Namespaces. They are in a feud. They are the iFields and the McDroids. The iFields ranch sheep and pigs and the McDroids ranch pigs and cows. Since both have pigs, they keep having conflicts. The two families will give you the Medallion of Namespaces if you can resolve the dispute and help them track their animals.

## Objectives

- Create a `Sheep` class in the `IField` namespace (fully qualified name of `IField.Sheep`).
- Create a `Pig` class in the `IField` namespace (fully qualified name of `IField.Pig`).
- Create a `Cow` class in the `McDroid` namespace (fully qualified name of `McDroid.Cow`).
- Create a `Pid` class in the `McDroid` namespace (fully qualified name of `McDroid.Pig`).
- For your main method, add `using` directives for both `IField` and `McDroid` namespaces. Make new instances of all four classes. There are no conflicts with `Sheep` and `Cow`, so make sure you can create new instances of those with `new Sheep()` and `new Cow()`. Resolve the conflicting `Pig` classes with either an alias or fully qualified names.
