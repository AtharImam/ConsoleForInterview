namespace HelperLibrary
{
    public class TestClass
    {
        public TestClass()
        {
            
        }
        protected private string Name { get; set; }
    }



    public class HelperPublic
    {
        protected internal class HelperProtectedInternal // works as its withing class.
        {
            
        }

        private class InnerTestClass
        {
            protected private string Name { get; set; }
        }

        class MyClass : InnerTestClass
        {

        }
    }

    class HelperPrivate : HelperPublic.HelperProtectedInternal
    {
        public HelperPrivate()
        {
           
        }
    }

    internal class HelperInternal
    {
    }

    //protected internal class HelperProtectedInternal
    //{
    // error ad class cannot be declare as private or protected
    //}
}
