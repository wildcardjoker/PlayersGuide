# Asynchronous Random Words

On the Island of Tasken, you meet Awat, who tells you that being a True Programmer can't be all that hard. His ancestors have been the stewards of the Asynchronous Medallion, yet Awat uses it as a food dish for his cat. "A thousand monoids with a thousand random generators will also eventually produce 'hello world'!" he claims. Indeed, they could, but you know it would take a while. With tasks, you can allow a human to pick a word and randomly generate the word asynchronously. Doing this will show Awat how long it will take to randomly generate the words `hello` and `world`, convincing him that a Programmer's skills mean something.

## Objectives

- Make the method `int RandomlyRecreate(string word)`. It should take the string's length and generate an equal number of random characters. It is okay to assume that all words only use lowercase letters. One way to randomly generate a lowercase letter is `(char)('a' + random.Next(26))`. This method should loop until it randomly generates the target word, counting the required attempts. The return value is the number of attempts.
- Make the method `Task <int> RandomlyRecreateAsync(string word)` that schedules the above method to run asynchronously (`Task.Run` is one option).
- Have your main method ask the user for a word. Run the `RandomlyRecreateAsync()` method and `await` its result and display it. **Note**: Be careful about long words! For me, a five-letter word took several seconds, and my math indicates that a 10-letter word may take nearly two years.
- Use `DateTime.Now` before and after the async task runs to measure the wall clock time it took. Display the time elapsed (level 32).
