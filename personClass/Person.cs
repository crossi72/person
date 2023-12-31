﻿using System.Net.Http.Headers;

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
		public string BirthProvince;
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
		public Person(string FirstName, string SecondName, GenderType Gender, string PlaceOfBirth, DateTime DateOfBirth) : this(FirstName, SecondName, Gender, PlaceOfBirth, "", DateOfBirth) {
		}

		/// <summary>
		/// Cosntructor
		/// </summary>
		/// <param name="FirstName">First name of the person</param>
		/// <param name="SecondName">Last name of the person</param>
		/// <param name="Gender">Gender name of the person</param>
		/// <param name="DateOfBirth">Date of birth of the person</param>
		/// <param name="PlaceOfBirth">City of birth of the person</param>
		/// <param name="ProvinceOfBirth">Province of birth of the person</param>
		public Person(string FirstName, string SecondName, GenderType Gender, string PlaceOfBirth, string ProvinceOfBirth, DateTime DateOfBirth){
			this.FirstName = FirstName;
			this.LastName = SecondName;
			this.Gender = Gender;
			this.BirthDate = DateOfBirth;
			this.BirthCity = PlaceOfBirth;
			this.BirthProvince = ProvinceOfBirth;
		}


		#endregion

		#region " Methods "

		public string FiscalCode() {
			string result, gender;

			//create an istance of CodiceFiscale class
			CodiceFiscaleUtility.CodiceFiscale FiscalCode;

			//adapt the Gender property to the string type required by CodiceFiscale class

			if (this.Gender == GenderType.NotSpecified) {
				//if gender is missing, can't calculate fiscal code
				result = "";
			} else {
				if (this.Gender == GenderType.Male) {
					gender = "M";
				} else {
					gender = "F";
				}

				try
				{
					FiscalCode = new CodiceFiscaleUtility.CodiceFiscale(this.LastName, this.FirstName, gender, this.BirthDate, this.BirthCity, this.BirthProvince);

					//use CodiceFiscale class to generate the fiscal code
					result = FiscalCode.Codice;
				} catch (Exception e) {
#if DEBUG
					result = e.StackTrace;
#else
					result= "";
#endif
				} finally {

				}
			}

			return result;
		}

		/// <summary>
		/// Calculates the age of the person
		/// </summary>
		/// <returns>The age of the person</returns>
		public int Age(){
			DateTime currentDate;
			int result;
		
			//get current date
			currentDate = DateTime.Now;

			//calculate years between the two date
			result = currentDate.Year - this.BirthDate.Year;

			//fix age if birthday is future
			if ((this.BirthDate.Month > currentDate.Month)
			|| (this.BirthDate.Month == currentDate.Month && 
				this.BirthDate.Day > currentDate.Day)){
				result -= 1;
			}

			return result;
		}

		#endregion
	}
}