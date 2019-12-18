# GE1Assignment
Repository for Games Engines 1 CA

## How It Works
This assignment inclused 2 audio visualisers. The audio file is analysed using the AudioAnalyser.cs file.
The first visualiser uses all 512 samples - the frame size - and displays a ring of cubes, coloured using a gradient.
These cubes increase in size along the y axis in response to the audio.

The second visualiser is a sequence of rows of cubes that are procedurally generated. There are 8 cubes in each row which
correspod to the 8 bins also created in the AudioAnalyser.cs file. The cubes increase and decrease in height along the
y axis in response to the audio, and the colour of the cubes change in response to that y value. These rows are spawned
using a co-routine so that I could set the speed that they appeared.

The camera moves forward at the same speed as the first visualiser, so that it seems to stay in the same place underneath
the cube rows.

I used the audio visualisation tutorials from class and from YouTube - (https://www.youtube.com/watch?v=5pmoP1ZOoNs&list=PL3POsQzaCw53p2tA6AWf7_AWgplskR0Vo) - and tried to expand on them to make something new
fun to look at.

## I'm Most Proud Of
The thing I'm most proud of about this assignment is how it looks. I was unsure I would get anything near a finished product,
but I ended up actually enjoying watching the program run.

## Instructions
Ensure the camera transform is as follows:

Position: X:-50, Y:12, Z:27.5
Rotation: X:0,   Y:90, Z:0

## YouTube Video Link
[![YouTube](http://img.youtube.com/vi/MAiowPVTQIw/0.jpg)](https://www.youtube.com/watch?v=MAiowPVTQIw)
