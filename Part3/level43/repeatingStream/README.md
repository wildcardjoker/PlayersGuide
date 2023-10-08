# The Repeating Stream

In Threadia, there is a stream that generates numbers once a second. The numbers are randomly generated, between `0` and `9`. Occasionally, the stream generates the same number more than once in a row. A repeat number like this is significant - an omen of good things to come. Unfortunately, since the Uncoded One's arrival, Threadians haven't been able to monitor the stream while it produces numbers. Either the stream generates numbers whyle nobody watches, or they watch while the stream produces no numbers. The Threadians offer you the Medallion of Threads willingly and ask you to use it to make both possible at the same time. Build a program to generate numbers while simultaneously allowing a user to flag repeats.

## Objectives

- Make a `RecentNumbers` class that holds at least the two most recent numbers.
- Make a method that loops forever, generating random numbers from `0` to `9` once a second. **Hint**: `Thread.Sleep` can help you wait.
- Write the numbers to the console window, put the generated numbers in a RecentNumbers object, and update it as new numbers are generated.
- Make a thread that runs the above method.
- Wait for the user to press a key in the second loop (on the main thread or another new thread). When the user presses a key, check if the last two numbers are the same. If they are, tell the user that they correctly identified the repeat. If they are not, indicate that they got it wrong.
- Use `lock` statements to ensure that only one thread accesses the shared data at a time.
