/*
 * The Four Sisters and the Duckbear
 *
 * Four sisters own a chocolate farm and collect chocolate eggs laid by chocolate chickens every day. But more often than not,
 * the number of eggs is not evenly divisible among the sisters, and everybody knows you cannot split a chocolate egg into pieces
 * without ruining it. the arguments have grown more heated over time. The town is tired of hearing the four sisters complain, and
 * Chandra, the town's Arbiter,has finally come up with a plan everybody can agree to. All four sisters get an equal number of
 * chocolate eggs every day, and the remainder is fed to their pet duckbear. All that is left is to have some skilled Programmer
 * build a program to tell them how much each sister and the duckbear should get.
 *
 * Objectives:
 *
 * Create a program that lets the user enter the number of chocolate eggs gathered that day.
 * Using / (divide) and % (mod/remainder), compute how many eggs each sister should get and how many are left over for the
 * duckbear.
 * Answer this question: What are three total egg counts where the duckbear gets more than each sister does? You can use the
 * program you created to help you find the answer.
 */

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