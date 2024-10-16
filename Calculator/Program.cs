﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
internal class Program
{
	static string LoadNumber()
	{
		return Console.ReadLine();
	}
	static void Main(string[] args)
	{
		double input1;
		char operation;
		double input2 = 1;
		double result = 0;
		bool enteredSecondNumber = false;
		char endCase;
		/*
		* ZADANI
		* Vytvor program ktery bude fungovat jako kalkulacka. Kroky programu budou nasledujici:
		* 1) Nacte vstup pro prvni cislo od uzivatele (vyuzijte metodu Console.ReadLine() - https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8.
		* 2) Zkonvertuje vstup od uzivatele ze stringu do integeru - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number.
		* 3) Nacte vstup pro druhe cislo od uzivatele a zkonvertuje ho do integeru. (zopakovani kroku 1 a 2 pro druhe cislo)
		* 4) Nacte vstup pro ciselnou operaci. Rozmysli si, jak operace nazves. Muze to byt "soucet", "rozdil" atd. nebo napr "+", "-", nebo jakkoliv jinak.
		* 5) Nadefinuj integerovou promennou result a prirad ji prozatimne hodnotu 0.
		* 6) Vytvor podminky (if statement), podle kterych urcis, co se bude s cisly dit podle zadane operace
		*    a proved danou operaci - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements.
		* 7) Vypis promennou result do konzole
		* 
		* Rozsireni programu pro rychliky / na doma (na poradi nezalezi):
		* 1) Vypis do konzole pred nactenim kazdeho uzivatelova vstupu co po nem chces (aby vedel, co ma zadat)
		* 2) a) Kontroluj, ze uzivatel do vstupu zadal, co mel (cisla, popr. ciselnou operaci). Pokud zadal neco jineho, napis mu, co ma priste zadat a program ukoncete.
		* 2) b) To same, co a) ale misto ukonceni programu opakovane cti vstup, dokud uzivatel nezada to, co ma
		*       - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
		* 3) Umozni uzivateli zadavat i desetinna cisla, tedy prekopej kalkulacku tak, aby umela pracovat s floaty
		*/
		START:
		Console.WriteLine("Hello, this is a calculator, enter the equation you want solved and I will solve it for you.");
		Console.WriteLine("Use only numbers and symbols (+,-,/,*,%,^,r,l,s,c,!) for mathematical operations. Use a comma (,) for a decimal number. Do not use spaces. If you want to raise a number use only whole numbers. For roots (r) the syntax is second numbers root of the first number. Sine (s) and Cosine (c) are in radians. For logarithms (l) the second number is the base of the logarithm. For factorials use only whole numbers.");
		INPUT1: 
		Console.WriteLine("Enter first number:");
		if (!double.TryParse(LoadNumber(), out input1)) //Reads first input and checks whether it is valid
		{
			Console.WriteLine("Number entered incorrectly. Did you use a period instead of a comma?");
			goto INPUT1;
		} 
		INPUTOP: 
		Console.WriteLine("Now enter the operator:");
		if (!char.TryParse(Console.ReadLine(), out operation)) //Reads operand input and then converts to char
		{
			Console.WriteLine("Operation entered incorrectly, please input only one character and make sure it is only one of the following: +, -, /, %, *, ^, r, s, c, l");
			goto INPUTOP;
		}
		switch ((int)operation) //Checks if operation needs a second number, if so, continues.
		{
			case 114:
				Console.WriteLine(Math.Sqrt(input1));
				goto END;
			case 115:
				Console.WriteLine(Math.Sin(input1));
				goto END;
			case 99:
				Console.WriteLine(Math.Cos(input1));
				goto END;
			case 33:
				Console.WriteLine(input1!);
				goto END;
			default:
				break;
		}
		if (enteredSecondNumber) {
			goto CALCULATE;
		}
		INPUT2:
		Console.WriteLine("Enter the second number:");
		if (!double.TryParse(LoadNumber(), out input2)) //Reads second input and checks whether it is valid
		{
			Console.WriteLine("Number entered incorrectly. Did you use a period instead of a comma?");
			goto INPUT2;
		}

		CALCULATE:
		switch ((int)operation) //Converts char of operation to ASCII position number and compares to value in lookup table
		{
			case 37: //ASCII character for per cent sign
			result = input1 % input2;
			Console.WriteLine(result); //Only used result here, it is easier to just print straight out.
			break;
			case 42:
			Console.WriteLine(input1 * input2);
			break;
			case 43:
			Console.WriteLine(input1 + input2);
			break;
			case 45:
			Console.WriteLine(input1 - input2);
			break;
			case 47:
			Console.WriteLine(input1 / input2);
			break;
			case 94:
			Console.WriteLine((int)input1 ^ (int)input2);
			break;
			case 108:
			Math.Log(input1,input2);
			break;
			default:
			Console.WriteLine("Error, entered an incorrect operand");
			enteredSecondNumber = true;
			goto INPUTOP;
		}
		END:
		Console.WriteLine("Do you want to continue? (y)es/(N)o"); //Asks whether or not usr wants to continue
		endCase = (char)Console.ReadKey().Key;
		if (endCase == 89)
		{ //Y is pressed
			enteredSecondNumber = false;
			goto START; //Goes to start, otherwise ends.
		}
	}
}
