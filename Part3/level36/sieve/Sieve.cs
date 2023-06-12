namespace sieve
{
    internal class Sieve
    {
        #region Constructors
        public Sieve(Predicate<int> compareFunction) => CompareFunction = compareFunction;
        #endregion

        #region Properties
        private Predicate<int> CompareFunction {get;}
        #endregion

        public bool IsGood(int number) => CompareFunction(number);
    }
}