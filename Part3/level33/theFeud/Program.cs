// Hooray, multiple files at last :)

#region Using Directives
using theFeud.IField;
using theFeud.McDroid;
using Pig = theFeud.IField.Pig;
#endregion

var sheep      = new Sheep();
var cow        = new Cow();
var iFieldPig  = new Pig();                 // uses alias
var mcDroidPig = new theFeud.McDroid.Pig(); // Qualified reference

sheep.Speak();
cow.Speak();
iFieldPig.Speak();
mcDroidPig.Speak();