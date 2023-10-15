# Many Random Words

Awat is impressed with what you did in the last challenge by thinks it could be better. "Why not generate `hello` and `world` in parallel?" he asks. "You do that, and I'll let you take this medallion off me."

## Objectives

- Modify your program from the previous challenge to allow the main thread to keep waiting for the user to enter more words. For every new word entered, create and run a task to compute the attempt count and the time elapsed and display the result, but then let that run asynchronously while you wait for the next word. You can generate many words in parallel this way. **Hint**: Moving the elapsed time and output logic to another `async` method may make this easier.
