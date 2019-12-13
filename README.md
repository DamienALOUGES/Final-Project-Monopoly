# Final-Project-Monopoly

## Game rules 


A set of player is giver. Each player play by rolling 2 dice and move forward by a number of positions equal to the sum of the numbers told by the 2 dice. Then the next player plays .
The game is composed of a board of 40 boxes (positions)
•	1 White begin box (0) : if the player is on it , he earn 400 euros.

•	37 colored Street boxes : if the player is on it , he can buy this street (the amount is defined by the color of the street) if he has enough money. If another player owns already this street, he has to pay taxes to the owner .

•	And 2 black boxes (10-30) : Visit Jail / in Jail .


In addition to that, on some of the boxes , the player will be asked to pick a Chance/Malus card .These cards are randomly picked in a list of cards. The stack of 30 Bonus/Malus cards :

•	8 money bonus of 100 euros : player earn 100 euros

•	8 money malus of 100 euros : player loose 100 euros

•	14 money bonus of 200 euros : player  earn 200 euros

If a player gets both dice with the same value, then he rolls the dice and moves again.
If a player is at position 10, he visits jail. If he is at position 30 , he goes to jail at position 10.
To get out of jail the player has to gets both dice with the same value or has to roll 3 time the dices (3 turn) without moving his position.


## Design Patterns

For this project we used 2 design pattern : 

•	Singleton Design Pattern

•	Visitor Design Pattern


#### 1/ Singleton Design Pattern : 

We used this pattern for the game board and the  list of cards.
In fact the singleton design pattern is a pattern that restricts the instantiation of a class to one object. So with this kind of class we can just instantiate one and only object.

So as there is only one game board and one stack of cards in the game, we need to have only one board object and one stack of cards object. Indeed the boxes of the game board and the cards are unique.
So we create one and unique board and stack for all the turns of all the games.


#### 2/ Visitor Design Pattern :

This pattern is used to manage whenever a player (visitor) “visit” a box (element visited) he is on or a card (element visited 2) he picks.
With the help of the visitor pattern we moved the operational logic from the  cards and boxes objects to the player class. And it is much more easier and clearer to manage.
Moreover , if the logic of operation changes (for example we want to change the price of a street) then we need to make change only in the visitor implementation rather than doing it in the element classes.

In the code : 
•	ObjectStructure : a class that holds all the elements (card-box) which can be used by visitors (player).

•	IVisitorElement : : Interface used to declare the visit operations for all times of visitable classes ( card -box ).

•	Player : all the Visit methods ( 2 ) declared in 'IVisitorElement' are implemented .Each player will be responsible for different operations.

•	IElement : Interface which declare the accept operation . This is the entry point which enables a card or a box ( element object) to be visited by a player (visitor object). 

•	Card – Box  : these classes implement the 'IElement' interface and defines the accept operation. The player (visitor object) is passed to this object using the accept operation.

####Alouges Damien
####Aproh Louise
