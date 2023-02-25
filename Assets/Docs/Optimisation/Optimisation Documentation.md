#Optimisation

##Introduction
For this optimisation, I used the built in Unity Profiler which allows for visual identification of what is causes performance drops within the game during runtime. The smaller the bars, the better the performance.

##GetComponent calls

###The issue
Unity has a function called GetComponent which is very commonly used to get a reference to a GameObject and edit it's public variables and access it's functions.
If this function is called very frame then it can cause for serious performance drops, especially if many entities call this every frame. The example code below simulates such a scenario:
	```
	public class GetComponentScript : MonoBehaviour
	{
		public int getComponentNumber;
		PlayerScript[] getComponentGameObjects;
		private void OnEnable()
		{
			getComponentGameObjects = new PlayerScript[getComponentNumber]; //This sets up the array so Unity doesn't error
		}
		void Update()
		{
			//This is here so when the getComponentNumber is increased, the array also increases to stop an overflow error in Unity
			if (getComponentNumber != getComponentGameObjects.Length)
			{
				getComponentGameObjects = new PlayerScript[getComponentNumber];
			}

			for (int i = 0; i < getComponentNumber; i++)
			{
				getComponentGameObjects[i] = GameObject.Find("Player").GetComponent<PlayerScript>(); //This simulates x amount of entities getting a component all at once

			}
		}
	}
	```
	
The graph below shows the performance drop when getComponentNumber is 1 and when it is 10000.

![getComponentNumberZero](/Images/GetComponentScriptBadOne.png)
Zero

![getComponentNumberTenThousand](/Images/GetComponentScriptBadTenThousand.png)
Ten Thousand

As seen it is very bad for the game itself.
	
	
###How to fix
The best way to fix this is to cache the GetComponent as a variable when first called so the object still has the reference every frame and doesn't need to search for it every frame. An example would be:

The best way for this to be fixed is to cache all the GetComponent calls using OnEnable, Awake or Start so the reference is stored when the object is first initalised. Modifying the code above gives:
	```
	public class GetComponentScript : MonoBehaviour
	{
		public int getComponentNumber;
		PlayerScript[] getComponentGameObjects;
		private void OnEnable()
		{
			getComponentGameObjects = new PlayerScript[getComponentNumber];
		}
		void Update()
		{
			//This will only activate if getComponentNumber is changed, simulating a OnEnable for this scenario
			if (getComponentNumber != getComponentGameObjects.Length)
			{
				getComponentGameObjects = new PlayerScript[getComponentNumber];

				for (int i = 0; i < getComponentNumber; i++)
				{
					getComponentGameObjects[i] = GameObject.Find("Player").GetComponent<PlayerScript>(); //This simulates x amount of entities getting a component all at once

				}
			}
		}
	}
	```
Running this with the same test bench as before gives this result:

![getComponentNumberZero](/Images/GetComponentScriptGoodOne.png)
Zero

![getComponentNumberTenThousand](/Images/GetComponentScriptGoodTenThousand.png)
Ten Thousand
	
Using this there is only a short spike, unlike calling it every frame allowing for the FPS to be higher.