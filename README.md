# ochrona_danych_6408

## Uruchomienie projektu

1. Do uruchomienia projektu niezbędny jest:
 - ASP.NET Core Runtime 6.0.1 -> https://dotnet.microsoft.com/en-us/download/dotnet/6.0
 - SDK 6.0.101 -> https://dotnet.microsoft.com/en-us/download/dotnet/6.0
 
 3. Projekt IdentityServerAspNetIdentity używa bazy danych SQLite do przechowywania konfiguracji oraz listy użytkowników. Przed pierwszym uruchomieniem należy zainicjować bazę danych. Aby tego dokonać należy przejść do katalogu projektu:
 ```
 cd src/IdentityServerAspNetIdentity
 ```
 a następnie uruchomić projekt w trybie 'seed':
 ```
 dotnet run -- seed
 ```
 W efekcie w konsoli powinniśmy zobaczyć:
 ```
 $ dotnet run -- seed
[18:08:08 Information] 
Seeding database...

[18:08:09 Debug] 
alice already exists

[18:08:09 Debug] 
bob already exists

[18:08:09 Information] 
Done seeding database.
 ```
 4. Teraz wszystkie projekty z solucji można uruchomić poleceniem `dotnet run` (przechodząc wcześniej do katalogu projektu) lub za pomocą Visual Studio.
 Wszystkie uruchomione aplikacje nasłuchują na porcie HTTPS 443. Do poprawnego działania może być wymagane dodanie certyfikatu developera (dev-certs) do zaufanych certyfikatów. Jeśli jeszcze nie zostało to zrobione należy uruchomić `dotnet dev-certs https –trust`.