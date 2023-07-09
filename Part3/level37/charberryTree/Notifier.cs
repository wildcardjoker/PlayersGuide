namespace charberryTree
{
    internal class Notifier
    {
        #region Constructors
        public Notifier(CharberryTree tree) => tree.Ripened += Tree_Ripened;
        #endregion

        private static void Tree_Ripened()
        {
            Console.WriteLine("A charberry fruit has ripened!");
        }
    }
}