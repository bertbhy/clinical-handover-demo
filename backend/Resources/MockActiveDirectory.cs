
namespace webapi.Resources
{
    public class MockActiveDirectory
    {
        public class Person : IPerson
        {
            public string sAMAccountName { get; set; }
            public string displayName { get; set; }
            public string mail { get; set; }
            public string password { get; set; }
        }
        public Person[] persons { get; private set; }
        public MockActiveDirectory()
        {
            persons = new Person[]{
                new Person(){sAMAccountName="bert", displayName="Bert B, HKCH P(IT)", mail= "bert@ha.org.hk", password="00000000" },
                new Person(){sAMAccountName="johnny", displayName="Johnny W, HKCH P(IT)", mail= "johnny@ha.org.hk", password="00000000" },
                new Person(){sAMAccountName="anna", displayName="Anna L, HKCH P(IT)", mail= "anna@ha.org.hk", password="00000000" },
                new Person(){sAMAccountName="debby", displayName="Debby L, HKCH P(IT)", mail= "debby@ha.org.hk", password="00000000" },
            };
        }
    }
}