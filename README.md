### Google Casual Game Bootcamp


I collect the tasks given during the Bootcamp period in this repository. I'm building a solar system with Unity.

<h3>First Task</h3>
<ul>
<li>Prefabs, textures and materials created. Scene design and size adjustment done.</li>
<li>Created scriptable object to hold planet data.</li>
<li>RotatePlanet script created and edited prefabs.</li>
<li>Print to log when planet completes one revolution.</li>
</ul>

In the first task, I made the planets revolve around the sun and itself. I also created particle effects for the sun.

https://user-images.githubusercontent.com/67235777/176276878-58ac4cad-d71c-4c9c-b89f-7c6e9bdb3786.mp4

<h3>Second Task</h3>

<ul>
<li>Project converted to URP.</li>
<li>Camera control was done with CameraController.</li>
<li>Added a panel that displays planet names when clicking on planets.</li>
<li>A shader graph was created for solar flares.</li>
<li>Removed particle effect on planets, added trail renderer instead.</li>
<li>AsteroidManager was created to create asteroids and AsteroidController was created to control asteroids.</li>
<li>An explosion particle effect was generated when the asteroid hit any planet.</li>
<li>Pressing the 1 to 8 keys allowed the camera to focus on the planets. When 0 is pressed, the camera refocuses on the sun.</li>
</ul>

In this task, I converted the project to URP. I added two shader graphs to the project. One of them was created to create solar flares and the other to add effects to the tails of asteroids. Script was written for camera control. If there is no action in the game for 3 seconds, the camera starts to rotate around the sun automatically. We can also rotate and zoom with the mouse. I created a panel where we can learn planet information when clicking on the planets. For now, only planet names are shown. Apart from these, I created scripts for the management and control of asteroids. Asteroids move to a random planet and when they hit that planet, a large explosion particle is played.



https://user-images.githubusercontent.com/67235777/178113164-0e8b765d-6207-4e48-a2bb-141f842a0b27.mp4

