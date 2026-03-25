# Equipment Rental System

## Opis projektu
Jest to prosta aplikacja, która symuluje system wypożyczania sprzętu (np. laptopów, kamer, projektorów).

Program pozwala tworzyć użytkowników, dodawać sprzęt oraz wykonywać operacje wypożyczeń i zwrotów. Na końcu wyświetlany jest raport podsumowujący.

## Funkcjonalności
- dodawanie użytkowników (student i pracownik)
- dodawanie sprzętu (laptop, projektor, kamera)
- wypożyczanie sprzętu z uwzględnieniem limitów
- zwrot sprzętu i naliczanie kary za spóźnienie
- oznaczanie sprzętu jako niedostępny
- raport końcowy
- wyświetlanie:
    - całego sprzętu
    - dostępnego sprzętu
    - aktywnych wypożyczeń użytkownika
    - przeterminowanych wypożyczeń


## Struktura projektu
Projekt podzieliłem na kilka części:
- Models – klasy danych (User, Equipment, Rental)
- Services – logika programu (RentalService, ReportService)
- Data – przechowywanie danych w pamięci (AppData)
- Program.cs – przykład użycia aplikacji

## Dlaczego taki podział
Starałem się oddzielić dane od logiki programu.  
Dzięki temu kod jest bardziej czytelny. Dodatkowo łatwiej można taki projekt rozbudowywać.

- Models przechowują tylko dane
- Services robią całą logikę
- Program.cs tylko pokazuje jak działa system

## Kohezja
Każda klasa ma jedno zadanie:
- RentalService: wypożyczenia
- ReportService: raport
- Models: dane

Dzięki temu klasy są prostsze i bardziej czytelne.

## Coupling
Klasy są ze sobą połączone w prosty sposób:
- Services korzystają z AppData
- Models nie zależą od Services

Dzięki temu można zmienić logikę bez zmiany modeli.

## Uruchomienie
Projekt można uruchomić w Riderze albo przez dotnet run.

## Dodatkowa informacja
Po zamknięciu programu ddane nie są zapisywane na stałe.