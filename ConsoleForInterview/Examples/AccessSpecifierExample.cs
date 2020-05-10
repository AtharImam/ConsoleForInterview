using HelperLibrary;

namespace ConsoleForInterview
{
    class AccessSpecifierExample
    {
        public static void Execute()
        {
            //default access specifier for the class is internal and for member is private.
            HelperPublic p = new HelperPublic();
            //HelperPublic.HelperPublic; error as internal
            //HelperPrivate helperPrivate = new HelperLibrary.HelperPrivate(); error due to private
            //HelperInternal helperInternal = new HelperLibrary.HelperInternal(); error due to internal
        }

        class SampleAccess : HelperPublic
        {
            public SampleAccess()
            {
                
            }
        }
    }
}
