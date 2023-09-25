# Navigating Operand City

The City of Operand is a carefully planned city, organised into city blocks, lined up north to south and east to west. Blocks are referred to by their coordinates in the city, as we saw in the Cavern of Objects. The inhabitants of the town use the following three types as they work with the city's blocks:

```` C#
public record BlockCoordinate(int Row, int Column);
public record BlockOffset(int RowOffset, int ColumnOffset);
public enum Direction {North, East, South, West}
````

`BlockCoordinate` refers to a specific block's location, `BlockOffset` is for relative distances between blocks, and `Direction` specifies directions. As we saw with the Cavern of Objects, rows start at `0` at the north end of the city and get bigger as you go south, while columns start at `0` on the west end of the city and get bigger as you go east.

The city has used these three types for a long time, but the problem is that they do not play nice with each other. The town is the steward of *three* Medallions of Code. They will give each of them to you if you can use them to help make life more manageable. Use the code above as a starting point for what you build.

In exchange for the Medallion of Operators, they ask you to make it easy to add a `BlockCoordinate` with a `Direction` and also with a `BlockOffset` to get new `BlockCoordinates`. Add operators to `BlockCoordinate` to achieve this.

## Objectives

- Use the code above as a starting point.
- Add an addition (`+`) operator to `BlockCoordinate` that takes a `BlockCoordinate` and a  `BlockOffset` as arguments and produces a new `BlockCoordinate` that refers to the one you would arrive at by starting at the original coordinate and moving by teh offset. That is, if we started at `(4, 3)` and had an offset of `(2, 0)`, we should end up at `(6, 3)`.
- Add another addition (`+`) operator to `BlockCoordinate` that takes a `BlockCoordinate` and a `Direction` as arguments and produces a new `BlockCoordinate` that is a block in the direction indicated. If we started at `(4, 3)` and went east, we should end up at `(4, 4)`.
- Write code to ensure that both operators work correctly.

# Indexing Operand City

In exchange for the Medallion of Indexers, the city asks for the ability to index a `BlockCoordinate` by a number: `block[0]` for the block's row and `block[1]` for the block's column. Help them in this quest by adding a get-only indexer to the `BlockCoordinate` class.

## Objectives

- Add a get-only indexer to `BlockCoordinate` to access items by an index: index `0` is the row, and index `1` is the column.
- **Answer this question**: Does an indexer provide many benefits over just referring to the `Row` and `Column` properties in this case? Explain your reasoning.

Answer: An indexer does not provide any benefits in this case, and actually makes the code harder to read. However, indexers could come in handy when you have a class with multiple properties where you commonly refer to the same properties.
