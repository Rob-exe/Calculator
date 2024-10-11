﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

double input1;
char operation;
double input2;
double result = 0;
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

Console.WriteLine("Hello, this is a calculator, enter the equation you want solved and I will solve it for you.");
Console.WriteLine("Use only numbers and symbols (+,-,/,*,%) for mathematical operations. Use a comma (,) for a decimal number. Do not use spaces. Enter first number:");
input1 = Double.Parse(Console.ReadLine()); //Reads first input
Console.WriteLine("Now enter the operator:");
operation = char.Parse(Console.ReadLine()); //Reads operator and then converts to char
Console.WriteLine("Enter the second number:");
input2 = Double.Parse(Console.ReadLine()); //Reads second input
switch ((int)operation) //Converts char of operation to ASCII position number and compares
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
	default:
	Console.WriteLine("Error");
	break;
}

Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
