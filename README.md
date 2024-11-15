# Application des principe SOLID

## S Single Responsibility Principle 

## Impl�mentation initiale et probl�matique

Dans un premier temps, la classe `Book` de ce projet combinait deux responsabilit�s distinctes :

1. V�hiculer les informations du livre (titre, auteur, nombre de pages), agissant comme un **DTO (Data Transfer Object)**.
2. Sauvegarder ces informations dans un fichier JSON via une m�thode `SaveToFile()`.

Cela posait un probl�me de respect du principe **S** de SOLID, car une seule classe assumait deux responsabilit�s. Cette conception entra�nait une confusion : lorsqu'une instance de `Book` �tait utilis�e pour transmettre des donn�es, elle exposait �galement la capacit� d'effectuer une action technique (sauvegarde), ce qui n'a pas de sens m�tier.

## Respect du principe S : La solution mise en place

Pour corriger ce probl�me, les responsabilit�s ont �t� s�par�es :

- La classe `Book` se concentre uniquement sur le transfert d'informations, en respectant son r�le de **DTO**.
- Une nouvelle classe `BookRepository` a �t� introduite pour g�rer la sauvegarde des donn�es dans un fichier JSON.

- Cette refactorisation rend le code :
- Cette s�paration garantit que chaque classe a une responsabilit� unique et bien d�finie, respectant ainsi le principe **Single Responsibility Principle** de SOLID.
- **Plus clair et maintenable** : Les changements dans la logique m�tier ou technique n'affectent plus qu'une classe sp�cifique.
- **Testable** : Chaque responsabilit� peut �tre test�e ind�pendamment.
- Si je dois ajouter une propri�t� comme le genre (fantasy, thriller, horreur), je modifierai Book, et pour lire ou sauvegarder un livre depuis une source de donn�es, cela rel�vera de BookRepository, car chaque classe a sa responsabilit� claire.