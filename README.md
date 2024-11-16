# Application des principe SOLID

## S Single Responsibility Principle : 
- **Une classe ou un module doit avoir une seule responsabilité** :cela signifie qu’elle doit se concentrer sur une seule tâche ou fonction bien définie, ce qui la rend plus simple à comprendre et à gérer.
- **Une seule raison de changer** : si une classe doit être modifiée, ce sera uniquement parce que sa responsabilité a évolué, ce qui évite d'impacter d'autres parties du code.


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

## **O : Open/Closed Principle**  
Une classe doit être **ouverte à l’extension** et **fermée à la modification**. Cela signifie qu'une classe
doit pouvoir être étendue pour prendre en charge de nouveaux scénarios métier sans avoir besoin de modifier son code existant. Ainsi, on réduit les risques de régression et on garantit une meilleure maintenabilité.

## Implémentation initiale et problématique  
Dans un premier temps, la classe `SurfaceCalculator` violait ce principe :  

- Pour ajouter une nouvelle forme (comme un cercle ou un triangle), il fallait modifier la méthode `ComputeSize` pour y intégrer la logique spécifique au calcul de surface de la nouvelle forme.  
- Cela entraînait une dépendance forte entre `SurfaceCalculator` et les formes, rendant le système fragile face aux évolutions et complexifiant la maintenance.  

## La solution mise en place  
Pour respecter le principe Open/Closed, la conception a été refactorisée :  

- Une classe abstraite `Shape` a été introduite, avec une propriété abstraite `Surface` permettant à chaque forme de définir sa propre logique de calcul de surface.  
- Désormais, `SurfaceCalculator` utilise uniquement la propriété `Surface` des formes pour calculer la somme totale, sans avoir besoin de connaître les détails spécifiques de chaque forme.  

Cette refactorisation garantit que :  

- **Ajout d'une nouvelle forme simplifié** : Pour ajouter une nouvelle forme (comme un triangle), il suffit de créer une nouvelle classe qui hérite de `Shape` et implémente sa logique propre. Aucune modification n’est nécessaire dans `SurfaceCalculator`.  
- **Code maintenable et extensible** : Les classes existantes restent inchangées, minimisant les risques d’introduire des erreurs.  

## Exemple pratique  
Si je dois ajouter un **Cercle** (avec une propriété `Rayon`) dans le futur, il suffira de :  
1. Créer une classe `Circle` héritant de `Shape`.  
2. Implémenter la propriété `Surface` dans cette classe avec la formule appropriée.  

Aucune modification ne sera nécessaire dans `SurfaceCalculator`, car celui-ci respecte désormais le principe Open/Closed de SOLID.  


## Le principe L (Liskov Substitution Principle)

Le **principe Liskov Substitution** stipule que si une méthode attend une classe de base (abstraite ou concrète), elle doit pouvoir fonctionner avec n’importe quelle classe dérivée sans modifier son comportement attendu. Cela garantit que les sous-classes respectent le contrat défini par leur classe mère, rendant le système extensible et robuste.

## Implémentation initiale et problématique

Dans notre implémentation initiale, la classe `SurfaceCalculator` utilisait la méthode `GetSurface()` définie dans `Shape`.  
- Si on passait une forme comme `Rectangle` ou `Squar`, tout fonctionnait correctement.  
- Mais lorsqu’une instance de `Line` (qui n’a pas de surface) était utilisée, cela provoquait une exception (`NotImplementedException`), cassant le comportement attendu.

## La solution mise en place

Pour respecter le principe Liskov Substitution :  
- Une nouvelle classe abstraite `ShapeWithSurface` a été introduite pour représenter les formes ayant une surface mesurable (`Rectangle`, `Squar`).  
- Les formes sans surface, comme `Line`, héritent directement de `Shape` sans être contraintes d’implémenter une méthode inutile.  

## Exemple pratique

 ### Ajouter un Cercle dans le futur :  
  1. Créer une nouvelle classe `Circle` héritant de `ShapeWithSurface`.  
  2. Implémenter la méthode `GetSurface` avec la formule appropriée.  
  3. Aucune modification n’est nécessaire dans `SurfaceCalculator`, car celui-ci ne dépend que de `ShapeWithSurface`.  

 ### Ajouter une ligne courbe (sans surface) :  
  1. Créer une nouvelle classe héritant de `Shape`.  
  2. Aucune contrainte inutile ne sera imposée, car `Shape` n’a pas de méthode comme `GetSurface`.

- Toutes les classes **respectent le contrat défini** par leur classe mère.  
- **Le système est extensible** : ajouter une nouvelle forme avec ou sans surface ne nécessite aucune
modification des classes existantes.  


## Le principe I (Interface Segregation Principle) 

Le **principe Interface Segregation** stipule qu'il est préférable de diviser une grande interface en plusieurs petites interfaces spécifiques, regroupées par logique métier. Cela permet d’éviter les effets de bord et de limiter l’exposition des fonctionnalités inutiles ou dangereuses dans certains contextes. Une interface doit fournir uniquement ce qui est pertinent pour son utilisateur.

## Problématique

Dans notre implémentation initiale, une seule interface `IRepository` combinait toutes 
les responsabilités (lecture et écriture).  
- Cette approche exposait des méthodes inutiles ou risquées dans certains contextes, comme 
la méthode `Delete` appelée dans une logique de lecture (`DisplayAllBook`), ce qui pouvait entraîner des effets de bord non souhaités.  
- La méthode combinait des rôles hétérogènes, rendant l’interface difficile à maintenir et
sujette aux erreurs.  

## Solution mise en place

Pour respecter le principe **Interface Segregation** :  
1. L’interface `IRepository` a été décomposée en deux interfaces spécifiques :  
   - **`IReadRepository`** : Pour les fonctionnalités de lecture (`GetByID`, `GetAll`).  
   - **`IWriteRepository`** : Pour les fonctionnalités d’écriture (`Add`, `Update`, `Delete`, `Save`).  

2. Une interface globale `IRepository` regroupe ces deux interfaces pour les cas où les deux logiques sont nécessaires.  

3. La méthode `DisplayAllBook` utilise uniquement `IReadRepository`, empêchant ainsi toute manipulation accidentelle des fonctionnalités d’écriture.

### Cette refactorisation garantit que :  
1. **Respect du principe Interface Segregation** : Les interfaces sont spécifiques et cohérentes avec leurs responsabilités.  
2. **Code sécurisé** : Les fonctionnalités inutiles dans certains contextes sont masquées, évitant les erreurs ou manipulations accidentelles.  
3. **Facilité d’évolution** : Les interfaces sont modulaires, ce qui simplifie l’ajout de nouvelles fonctionnalités sans impact sur les classes existantes.  

## Exemple pratique

- Si une nouvelle méthode liée à la lecture doit être ajoutée,
elle sera intégrée dans `IReadRepository`, sans affecter les interfaces ou classes liées à l’écriture.  
- Inversement, une méthode liée à l’écriture sera ajoutée dans `IWriteRepository`.  
- Cette séparation garantit que les utilisateurs ne manipuleront que les fonctionnalités
pertinentes pour leur logique métier.

