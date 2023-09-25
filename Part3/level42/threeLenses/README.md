# The Three Lenses

The Guardian of the Medallion of Queries, Lennik, has long awaited when he can return the Medallion to a worth programmer. But he only wants to give it to somebody who truly understands the value of queries. He requires you to build a solution to a simple problem three times over. Lennik gives you the following array of positive numbers: `[1,9,2,8,3,7,4,6,5]`. He asks you to make a new collection from this data where:

- All the odd numbers are filtered out, and only the even should be considered.
- The numbers are in order.
- The numbers are doubled.

For example, with the array above, the odd/even filter should result in `2,8,4,6`. The ordering step should result in `2,4,6,8`. The doubling step should result in `4,8,12,16` as the final answer.

## Objectives

- Write a method that will take an `int[]` as input and produce an `IEnumerable<int>` (it could be a list or array if you want) that meets all three of the conditions above *using only procedural code* - `if` statements, switches, and loops. **Hint**: the static `Array.Sort` method might be a useful tool here.
- Write a method that will take an `int[]` as input and produce an `IEnumerable<int>` that meets the three above conditions *using a keyword-based query expression* (`from x`, `where x`, `select x`, etc.)
- Write a method that will take an `int[]` as input and produce an `IEnumerable<int>` that meets the three above conditions *using a method-call-based query expression* (`x.Select(n => n+1)`, `x.Where(n => n<0)`, etc.)
- Run all three methods and display the results to ensure they all produce good answers.
- **Answer this question**: Compare the size and understandability of these three approaches. Do any stand out as being particularly good or particularly bad?
- **Answer this question**: Of the three approaches, which is your personal favourite, and why?
