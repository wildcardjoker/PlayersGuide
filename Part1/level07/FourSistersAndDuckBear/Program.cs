var numberOfSisters = 4;
Console.WriteLine("Four Sisters and a Duckbear");
Console.WriteLine("How many chocolate eggs did the chocolate chickens lay today?");

// Again, there's no validation here - Make sure you enter a number!
var totalEggs = Convert.ToInt32(Console.ReadLine());

// Calculate how many eggs each sister gets
var eggsPerSister = totalEggs / numberOfSisters;

// Calculate how many eggs are left over
var leftoverEggs = totalEggs % numberOfSisters;

Console.WriteLine($"Each sister gets {eggsPerSister} egg(s)");
Console.WriteLine($"The duckbear gets {leftoverEggs} egg(s)");

/*
* Answer this question: What are three  total egg counts where the duckbear gets more than each sister does? You can use the
* program you            created to help you  find the answer.
 *
 * 1)  6 (1 per sister, duckbear gets 2)
 * 2)  7 (1 per sister, duckbear gets 3)
 * 3) 11 (2 per sister, duckbear gets 3)
*/