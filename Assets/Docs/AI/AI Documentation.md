###AI within Dream Collection

##Introduction
Within this project, I used an AI route called "Behaviour Trees" in order to make and manage the AI.

##Node
This class is the foundation for the behaviour trees. It holds a NodeState which is either: Running, Failure or Success.

##Inverter
This class takes in the node and inverts it state, so failure becomes success and vice versa (running is unchanged)

##Selector
This class runs through each of the nodes placed in it and returns Failure if *all* the nodes are Failure, unlike Sequence.

##Sequence
This class runs through each of the nodes placed in it and returns Failure if *one* of the nodes are Failure, unlike Selector.

##Chase Player
This node takes in the *origin*, *target* and the *moveSpeed*. With these, the node causes the AI to move towards the *target* based on the *moveSpeed*.

##Damage Player
This node takes in the *origin*, *target*, *damageDealt* and *damageCooldown*. With these, the node causes the AI to damage the *target* based on the *damageDealt* and won't attack again until *damageCooldown* seconds has passed.

##Destory Me
This node takes in the *origin* and destroys the *origin*.

##Is Player In Range
This node takes in the *origin*, *target* and *maxThreshold*. With these, the node causes the AI to return Success if the *target* is within *maxThreshold*. If the *target* is outside the *maxThreshold* then the AI returns Failure.

