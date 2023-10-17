using System.Net.Http.Headers;

namespace personClass
{

	/// <summary>
	/// Manages personal information
	/// </summary>
	public class Person
	{

		#region " Data types "

		public enum GenderType{
			 Male,
			 Female,
			 NotSpecified
		}

		#endregion

		#region " Properties "

		public string FirstName;
		public string LastName;
		public DateTime BirthDate;
		public string BirthCity;
		public GenderType Gender;

		#endregion

		#region " Constructors "

		/// <summary>
		/// Basic constructor
		/// </summary>
		public Person() : this("", "", GenderType.NotSpecified, "", new DateTime(1900, 1, 1))
		{
		}

		/// <summary>
		/// Cosntructor
		/// </summary>
		/// <param name="FirstName">First name of the person</param>
		/// <param name="SecondName">Second name of the person</param>
		public Person(string FirstName, string SecondName) : this(FirstName, SecondName, GenderType.NotSpecified , "", new DateTime(1900, 1, 1))
		{
		}

		/// <summary>
		/// Cosntructor
		/// </summary>
		/// <param name="FirstName">First name of the person</param>
		/// <param name="SecondName">Second name of the person</param>
		/// <param name="Gender">Gender name of the person</param>
		public Person(string FirstName, string SecondName, GenderType Gender) : this(FirstName, SecondName, Gender, "", new DateTime(1900,1,1) ) {
		}

		/// <summary>
		/// Cosntructor
		/// </summary>
		/// <param name="FirstName">First name of the person</param>
		/// <param name="SecondName">Last name of the person</param>
		/// <param name="Gender">Gender name of the person</param>
		/// <param name="DateOfBirth">Date of birth of the person</param>
		/// <param name="PlaceOfBirth">City of birth of the person</param>
		public Person(string FirstName, string SecondName, GenderType Gender, string PlaceOfBirth, DateTime DateOfBirth){
			this.FirstName = FirstName;
			this.LastName = SecondName;
			this.Gender = Gender;
			this.BirthDate = DateOfBirth;
			this.BirthCity = PlaceOfBirth;
		}


		#endregion
	}
}