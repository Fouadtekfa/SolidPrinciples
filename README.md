# Application des principe SOLID

## S Single Responsibility Principle 

## Implémentation initiale et problématique

Dans un premier temps, la classe `Book` de ce projet combinait deux responsabilités distinctes :

1. Véhiculer les informations du livre (titre, auteur, nombre de pages), agissant comme un **DTO (Data Transfer Object)**.
2. Sauvegarder ces informations dans un fichier JSON via une méthode `SaveToFile()`.

Cela posait un problème de respect du principe **S** de SOLID, car une seule classe assumait deux responsabilités. Cette conception entraînait une confusion : lorsqu'une instance de `Book` était utilisée pour transmettre des données, elle exposait également la capacité d'effectuer une action technique (sauvegarde), ce qui n'a pas de sens métier.

## Respect du principe S : La solution mise en place

Pour corriger ce problème, les responsabilités ont été séparées :

- La classe `Book` se concentre uniquement sur le transfert d'informations, en respectant son rôle de **DTO**.
- Une nouvelle classe `BookRepository` a été introduite pour gérer la sauvegarde des données dans un fichier JSON.

- Cette refactorisation rend le code :
- Cette séparation garantit que chaque classe a une responsabilité unique et bien définie, respectant ainsi le principe **Single Responsibility Principle** de SOLID.
- **Plus clair et maintenable** : Les changements dans la logique métier ou technique n'affectent plus qu'une classe spécifique.
- **Testable** : Chaque responsabilité peut être testée indépendamment.
- Si je dois ajouter une propriété comme le genre (fantasy, thriller, horreur), je modifierai Book, et pour lire ou sauvegarder un livre depuis une source de données, cela relèvera de BookRepository, car chaque classe a sa responsabilité claire.