
//print menu
using System.Globalization;

PrintMenu();

/// <summary>
/// Prints menu
/// </summary>
 void PrintMenu()
{
	string Command;
	personClass.Person Person;

	Person = new personClass.Person();

	do
	{
		//print menu
		Menu();

		//leggo l'input dell'utente
		Command = Console.ReadLine();

		//call user selected option
		switch (Command)
		{
			case "1":
				ReadPersonData(Person);

				break;
			case "2":
				try
				{
					PrintFiscalCode(Person);
				} catch (Exception ex) { }
					Console.WriteLine("Errore nei dati: verifcare i dati e riprovare");
				break;
			case "3":
				PrintAge(Person);

				break;
			case "0":
				//exit
				break;
			default:
				//continue loop
				break;
		}
		//if user selected "0", exit
	} while (Command != "0");
}


#region " Methods "

/// <summary>
/// Prints menu options
/// </summary>
void Menu()
{
	Console.WriteLine("Seleziona un comando");
	Console.WriteLine("1) Inserisci dati");
	Console.WriteLine("2) Stampa codice fiscale");
	Console.WriteLine("3) Stampa età");
	Console.WriteLine("0) Esci");
}

/// <summary>
/// Read person data from console
/// </summary>
void ReadPersonData(personClass.Person Person){
	Person.FirstName = ReadStringFromConsole("Inserisci il nome");
	Person.LastName = ReadStringFromConsole("Inserisci il cognome");
	Person.BirthCity = ReadStringFromConsole("Inserisci la città di nascita");
	Person.BirthProvince = ReadStringFromConsole("Inserisci la provincia di nascita");
	Person.BirthDate = ReadDateFromConsole("Inserisci la data di nascita");
	Person.Gender = ReadGenderFromConsole("Inserisci il genere");
}


string ReadStringFromConsole(string message){
	//ask data
	Console.WriteLine(message);
	//read data
	return Console.ReadLine();
}

DateTime ReadDateFromConsole(string message){
	string input;
	//ask data
	Console.WriteLine(message);
	//read data
	input = Console.ReadLine();
	return DateTime.ParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
	}

personClass.Person.GenderType ReadGenderFromConsole(string message){
	string value;
	personClass.Person.GenderType result;

	//ask data
	Console.WriteLine(message);
	//read data
	value = Console.ReadLine();

	if ((value.ToUpper() == "M") || (value.ToUpper() == "MASCHIO")){
		result = personClass.Person.GenderType.Male;
	} else if ((value.ToUpper() == "F") || (value.ToUpper() == "FEMMINA")){
		result = personClass.Person.GenderType.Female;
	} else {
		result = personClass.Person.GenderType.NotSpecified;
	}

	return result;
}

void PrintFiscalCode(personClass.Person Person){
	Console.WriteLine(Person.FiscalCode());
}

void PrintAge(personClass.Person Person){
	Console.WriteLine(Person.Age());
}

#endregion