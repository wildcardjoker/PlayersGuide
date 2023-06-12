namespace sieve
{
    internal class Sieve
    {
        #region Constructors
        public Sieve(NumeromechanicalDelegate compareFunction) => CompareFunction = compareFunction;
        #endregion

        #region Properties
        private NumeromechanicalDelegate CompareFunction {get;}
        #endregion

        public bool IsGood(int number) => CompareFunction(number);
    }
}