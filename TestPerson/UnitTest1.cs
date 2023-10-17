namespace TestPerson
{
	[TestClass]
	public class TestPerson
	{
		[TestMethod]
		public void TestConstructors()
		{
			//declare variable
			personClass.Person myPerson;

			//test parametless constructor
			myPerson = new personClass.Person();

			//test constructor
			myPerson = new personClass.Person("Mario", "Rossi");

			//test constructor
			myPerson = new personClass.Person("Mario", "Rossi", personClass.Person.GenderType.Male);

			//test constructor
			myPerson = new personClass.Person("Mario", "Rossi", personClass.Person.GenderType.Male, "Roma", new DateTime(2000, 10, 15));
		}
	}
}