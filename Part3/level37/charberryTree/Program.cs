#region Using Directives
using charberryTree;

// ReSharper disable UnusedVariable
#pragma warning disable IDE0059
#endregion

var tree      = new CharberryTree();
var notifier  = new Notifier(tree);
var harvester = new Harvester(tree);

while (true)
{
    tree.MaybeGrow();
}