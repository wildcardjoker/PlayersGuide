namespace sieve
{
    internal class Sieve
    {
        #region Constructors
        public Sieve(Func<int, bool> compareFunction) => CompareFunction = compareFunction;
        #endregion

        #region Properties
        private Func<int, bool> CompareFunction {get;}
        #endregion

        public bool IsGood(int number) => CompareFunction(number);
    }
}