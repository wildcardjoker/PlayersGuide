# Vin Fletcher's Arrows

Vin Fletcher is a skilled arrow maker. He asks for your help building a new class to represent arrows and determine how much he should sell them for.

"A tiny fragment of my soul goes into each arrow; I care not for the money; I just need to be able to recoup my costs and get food on the table," he says.

Each arrow has three parts: the `arrowhead` (`steel`, `wood`, or `obsidian`), the `shaft` (a length between `60` and `100` cm long), and the `fletching` (`plastic`, `turkey feathers`, or `goose feathers`).

His costs are as follows:

- For `arrowheads`:
  - `steel` costs `10` gold
  - `wood` costs `3` gold
  - `obsidian` costs `5` gold
- For `fletching`:
  - `plastic` costs `10` gold
  - `turkey feathers` cost `5` gold
  - `goose feathers` cost `3` gold
- For the shaft:
  - The price depends on the length: `0.05` gold per cm

## Objectives

- Define a new `Arrow` class with fields for `arrowhead` type, `fletching` type, and `length`. (**Hint**: `arrowhead` types and `fletching` might be good enumerations).
- Allow a user to pick the `arrowhead`, `fletching`, and `length` and then create a new `Arrow` instance.
- Add a `GetCost` method that returns its cost as a `float` based on the numbers above, and use this to display the arrow's cost.
