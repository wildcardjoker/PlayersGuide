namespace charberryTree
{
    internal class Harvester
    {
        #region Fields
        private readonly CharberryTree _tree;
        #endregion

        #region Constructors
        public Harvester(CharberryTree tree)
        {
            _tree         =  tree;
            _tree.Ripened += Tree_Ripened;
        }
        #endregion

        private void Tree_Ripened()
        {
            Console.WriteLine("The charberry fruit has been harvested.");
            _tree.Ripe = false;
        }
    }
}