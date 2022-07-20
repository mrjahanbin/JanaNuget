# Welcome to Jana Pack!

**Jana Pack** is a collection of methods needed for the development of your software.



# DateTimeConvertor

|                |Need|Sample|
|----------------|-------------------------------|-----------------------------|
|ToMiladiDate|`1368,09,11 ==> 1989, 12, 02`      |var Act = Input.ToMiladiDate();
|ToMiladiDateTime|`1368,9,11 08:37:15 AM ==> 1989, 12, 02 08:37:15 AM `  |var Act = Input.ToMiladiDateTime();            |
|ToMiladiYear|`1368,9,11 ==> 1989`      |var Act = Input.ToMiladiYear();|
|ToShamsi|`1989, 12, 02 ==> 1368,09,11`      |var Act = Input.ToShamsi();
|ToShamsiDateTime|`1989, 12, 02 08:37:15 AM ==> 1368,9,11 08:37:15 AM `  |var Act = Input.ToShamsiDateTime();            |
|ToShamsiYear|` 1989, 12, 02 ==> 1368`      |var Act = Input.ToShamsiYear();|


# NumberConvertor

|                |Need|Sample|
|----------------|-------------------------------|-----------------------------|
|ToPercent|`622.12345 ==> 622.1234`      |var Act = Input.ToPercent();
|ToPercentString|`1234.12345 ==> 1,234.1234`  |var Act = Input.ToPercentString();  
|ToPercentString|`1234.12345 ==> 1234.1234`  |var Act = Input.ToPercentString(false);            |
|ToPercent|`622.12345 ==> 622.1234`      |var Act = Input.ToPercent();|
|ToPercent|`622.123456 ==> 622.12345`      |var Act = Input.ToPercent(5);|
|ToDecimal|`622.12345 ==> 622.1234`      |var Act = Input.ToDecimal();
|ToDecimal|`622.123456 ==> 622.12345`      |var Act = Input.ToDecimal(5);
|ToCurrency|`622.12345 ==> 622`  |var Act = Input.ToCurrency();            |
|ToCurrency|`6,123.12345 ==> 6,123.1234`  |var Act = Input.ToCurrency(#,0.####);            |

# Fixer

|                |Need|Sample|
|----------------|-------------------------------|-----------------------------|
|Fix|`"   12   3   " ==> "12 3"`      | value = Fixer.Fix(value);

