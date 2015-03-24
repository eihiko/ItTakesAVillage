# ItTakesAVillage


### Navigation of the overworld.

One is being able to explore the area as an avatar. Outside:
Mouse:
- Free movement in any direction.
- Right-click:
     - player walks toward cursor
     - During a walk, stop the player immediately by clicking him/her.
     - If Double-Click: Player runs toward cursor.
        - More like insta-travel… player will look like he or she is dashing immediately toward cursor, but is actually warped to that position.
- Left-click: Interact with objects
     - Player will walk toward object
     - Run toward object if double-click
          - More like insta-travel… player will look like he or she is dashing immediately toward cursor, but is actually warped to that object.


### Using GameControl to save:

In order to use the GameControl script, attach the script
to an empty object for every scene in the game. The object
should persist between scenes correctly.

You can access any of the public methods in GameControl
such as the getter/setter methods. GameControl currently
supports saving and loading as well as resource 
adjusting (IncResources & DecResources). 
