Command Design Pattern:
The command design pattern was used to make the shooting mechanic work, where it would take the position of the mouse, translate that to the world position, then ray cast to see if it collided with a duck. the shot inverting was also applied in the command as a parameter. The Command returns a Collider2D of the hit object, and also outs a vector3 of the position clicked.

Object Pooling:
Object Pooling was used to spawn the ducks while initializing the game, and the calling on a select few at a time, then disabling the ones that were not being used so they could be reused later instead of destroying them.

Other Pattern:
I used the singleton design pattern for my game manager script, which was the backbone of most general statistics in the game. It has the code that ensures that only one instance of it can exist, which makes it a singleton.