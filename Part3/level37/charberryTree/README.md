# Charberry Tree

The Island of Eventia survives by harvesting and earting the fruit of the native charberry trees. Harvesting charberry fruit requires three people and an afternoon, but two is enough to feed a family for a week.

Charberry trees fruit randomly, requiring somebody to frequently check in on the plants to notice one has fruited. Eventia will give you the Medallion of Events if you can help them with two things:

1. automatically notify people as soon as a tree ripens; and
2. automatically harvest the fruit.

Their tree looks like this:

    CharberryTree tree = new CharberryTree();

    while (true)
        tree.MaybeGrow();

    public class CharberryTree
    {
        private Random _random = new Random();
        public bool Ripe {get; set;}
    
        public void MaybeGrow()
        {
            // Only a tiny chance of ripening each time, but we try a lot!
            if (_random.NextDouble() < 0.00000001 && !Ripe)
            {
                Ripe = true;
            }
        }
    }

## Objectives

- Make a new project that includes the above code.
- Add a `Ripened` event to the `CharberryTree` class that is raised when the tree ripens.
- Make a `Notifier` class that knows about the tree (**Hint**: perhaps pass it in as a constructor parameter) and subscribes to its `Ripened` event. Attach a handler that displays something like "A charberry fruit has ripened!" to the console window.
- Make a `Harvester` class that knows about the tree (**Hint**: like the notifier, this could be passed as a constructor parameter) and subscribes to its `Ripened` event. Attach a handler that sets the tree's `Ripe` property back to `false`.
- Update your main method to create a tree, notifier, and harvester, and get them to work together to grow, notify, and harvest forever.