# Application des principe SOLID

## S Single Responsibility Principle : 
- **Une classe ou un module doit avoir une seule responsabilit�** :cela signifie qu�elle doit se concentrer sur une seule t�che ou fonction bien d�finie, ce qui la rend plus simple � comprendre et � g�rer.
- **Une seule raison de changer** : si une classe doit �tre modifi�e, ce sera uniquement parce que sa responsabilit� a �volu�, ce qui �vite d'impacter d'autres parties du code.


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

## **O : Open/Closed Principle**  
Une classe doit �tre **ouverte � l�extension** et **ferm�e � la modification**. Cela signifie qu'une classe
doit pouvoir �tre �tendue pour prendre en charge de nouveaux sc�narios m�tier sans avoir besoin de modifier son code existant. Ainsi, on r�duit les risques de r�gression et on garantit une meilleure maintenabilit�.

## Impl�mentation initiale et probl�matique  
Dans un premier temps, la classe `SurfaceCalculator` violait ce principe :  

- Pour ajouter une nouvelle forme (comme un cercle ou un triangle), il fallait modifier la m�thode `ComputeSize` pour y int�grer la logique sp�cifique au calcul de surface de la nouvelle forme.  
- Cela entra�nait une d�pendance forte entre `SurfaceCalculator` et les formes, rendant le syst�me fragile face aux �volutions et complexifiant la maintenance.  

## La solution mise en place  
Pour respecter le principe Open/Closed, la conception a �t� refactoris�e :  

- Une classe abstraite `Shape` a �t� introduite, avec une propri�t� abstraite `Surface` permettant � chaque forme de d�finir sa propre logique de calcul de surface.  
- D�sormais, `SurfaceCalculator` utilise uniquement la propri�t� `Surface` des formes pour calculer la somme totale, sans avoir besoin de conna�tre les d�tails sp�cifiques de chaque forme.  

Cette refactorisation garantit que :  

- **Ajout d'une nouvelle forme simplifi�** : Pour ajouter une nouvelle forme (comme un triangle), il suffit de cr�er une nouvelle classe qui h�rite de `Shape` et impl�mente sa logique propre. Aucune modification n�est n�cessaire dans `SurfaceCalculator`.  
- **Code maintenable et extensible** : Les classes existantes restent inchang�es, minimisant les risques d�introduire des erreurs.  

## Exemple pratique  
Si je dois ajouter un **Cercle** (avec une propri�t� `Rayon`) dans le futur, il suffira de :  
1. Cr�er une classe `Circle` h�ritant de `Shape`.  
2. Impl�menter la propri�t� `Surface` dans cette classe avec la formule appropri�e.  

Aucune modification ne sera n�cessaire dans `SurfaceCalculator`, car celui-ci respecte d�sormais le principe Open/Closed de SOLID.  


## Le principe L (Liskov Substitution Principle)

Le **principe Liskov Substitution** stipule que si une m�thode attend une classe de base (abstraite ou concr�te), elle doit pouvoir fonctionner avec n�importe quelle classe d�riv�e sans modifier son comportement attendu. Cela garantit que les sous-classes respectent le contrat d�fini par leur classe m�re, rendant le syst�me extensible et robuste.

## Impl�mentation initiale et probl�matique

Dans notre impl�mentation initiale, la classe `SurfaceCalculator` utilisait la m�thode `GetSurface()` d�finie dans `Shape`.  
- Si on passait une forme comme `Rectangle` ou `Squar`, tout fonctionnait correctement.  
- Mais lorsqu�une instance de `Line` (qui n�a pas de surface) �tait utilis�e, cela provoquait une exception (`NotImplementedException`), cassant le comportement attendu.

## La solution mise en place

Pour respecter le principe Liskov Substitution :  
- Une nouvelle classe abstraite `ShapeWithSurface` a �t� introduite pour repr�senter les formes ayant une surface mesurable (`Rectangle`, `Squar`).  
- Les formes sans surface, comme `Line`, h�ritent directement de `Shape` sans �tre contraintes d�impl�menter une m�thode inutile.  

## Exemple pratique

- **Ajouter un Cercle dans le futur** :  
  1. Cr�er une nouvelle classe `Circle` h�ritant de `ShapeWithSurface`.  
  2. Impl�menter la m�thode `GetSurface` avec la formule appropri�e.  
  3. Aucune modification n�est n�cessaire dans `SurfaceCalculator`, car celui-ci ne d�pend que de `ShapeWithSurface`.  

- **Ajouter une ligne courbe (sans surface)** :  
  1. Cr�er une nouvelle classe h�ritant de `Shape`.  
  2. Aucune contrainte inutile ne sera impos�e, car `Shape` n�a pas de m�thode comme `GetSurface`.

- Toutes les classes **respectent le contrat d�fini** par leur classe m�re.  
- **Le syst�me est extensible** : ajouter une nouvelle forme avec ou sans surface ne n�cessite aucune
modification des classes existantes.  
