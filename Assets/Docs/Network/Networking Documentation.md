###Networking within Dream Collection

##Introduction
Within this document I used a networking manager called Forge Networking Remastered by Bearded Man Studios Inc. This asset was free on the Unity Asset Store and allowed for networking to be implimented without having to code the entire low level part of the network.

##PlayerRoot
The first use of networking is in PlayerRoot. This area of the code sets up how the players will look, destroys components where needed and updates the position and rotation of the players.

The player's looks and component destruction is all dealt with in the Network Start whilst the position and rotation of the player is dealt with in Update.

Position and Rotation are fields which are held within the networkObject and can be get or set.

##DreamObject
Within the Dream Object side of the networking deals with spawning in the enemies and adding to the score count.

When a player runs into this GameObject, an RPC is sent to all players on whether to spawn in an enemy or add to the score, relaying this way is done due to this being the easiest way to make sure that all players do the same thing when the interaction is completed.

Both client and host do this task, not just the host.

##DreamSpawner
This part of the networking deals with spawning in the DreamObject and how long to wait before trying to spawn one in.

Only the host deals with the timing on when to spawn in the object and sends an RPC to let the clients know when to spawn in the DreamObject and both host and client deal with this section.

Another thing is that NetworkManager.Instance.InstantiateDreamObject() is called. This spawns in the specified object and links it up to the network and not locally unlike GameObject.Instanciate().

##MasterDreamCollection
Master Dream Collection is a hub for holding all information such as the score, the current spawned in Dream Objects and displaying it to the UI.

The score itself is a field held by the gameObject and is shared by both host and clients, unlike RPCs which send a bit of information before resetting.

