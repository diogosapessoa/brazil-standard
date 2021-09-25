# Brazil Standard

Brazilian Standard Library

## Installation

**``Brazil.Standard`` is available on NuGet** [![NuGet](https://img.shields.io/nuget/v/Brazil.Standard.svg)](https://www.nuget.org/packages/Csv.Csharp/)

```console
PM> Install-Package Brazil.Standard -version 1.0.0
```

## Getting Started

### CPF

```csharp
//Exceptions: ArgumentException, ArgumentOutOfRangeException, FormatException, InvalidValueException
var cpf = new Cpf("84683214008");
//Or
//var cpf = new Cpf("846.832.140-08");
//Or
//var cpf = new Cpf(84683214008U);

Console.WriteLine(cpf.Length);//11
Console.WriteLine(cpf.Value);//84683214008U
Console.WriteLine(cpf.Text);//84683214008
Console.WriteLine(cpf.Formatted);//846.832.140-08

cpf == "84683214008"//True
cpf == "846.832.140-08"//True
cpf == 84683214008U//True
```

### CNPJ

```csharp
//Exceptions: ArgumentException, ArgumentOutOfRangeException, FormatException, InvalidValueException
var cnpj = new Cnpj("97962942000192");
//Or
//var cnpj = new Cnpj("97.962.942/0001-92");
//Or
//var cnpj = new Cnpj(97962942000192U);

Console.WriteLine(cnpj.Length);//14
Console.WriteLine(cnpj.Value);//97962942000192U
Console.WriteLine(cnpj.Text);//97962942000192
Console.WriteLine(cnpj.Formatted);//97.962.942/0001-92

cnpj == "97962942000192"//True
cnpj == "97.962.942/0001-92"//True
cnpj == 84683214008U//True
```

### BRAZILPHONE

```csharp
//Exceptions: ArgumentException, ArgumentOutOfRangeException, FormatException
var phone = new BrazilPhone("83996942822");
//Or
//var phone = new BrazilPhone("+5583996942822");
//Or
//var phone = new BrazilPhone("(83)99694-2822");
//Or
//var phone = new BrazilPhone("83996942822U");

Console.WriteLine(phone.Value);//83996942822U
Console.WriteLine(phone.Text);//83996942822
Console.WriteLine(phone.Formatted);//(83)99694-2822
Console.WriteLine(phone.AreaCode);//83
Console.WriteLine(phone.International);//+5583996942822

phone == "83996942822"//True
phone == "(83)99694-2822"//True
phone == 83996942822U//True
```
