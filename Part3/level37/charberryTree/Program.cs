#region Using Directives
using charberryTree;
#endregion

var tree     = new CharberryTree();
var notifier = new Notifier(tree);

while (true)
{
    tree.MaybeGrow();
}