# pianoWFC
## uses
- Metronome.cs by bzgeb (https://gist.github.com/bzgeb/c298c6189c73b2cf777c)
- UnityPianoGame by ukushu (https://github.com/ukushu/UnityPianoGame)
- unity-wave-function-collapse by selfsame (https://selfsame.itch.io/unitywfc)

## i'm gonna be honest with you
there would've been more time put into this if there hadn't been a minor apocalypse happening contemporaneously. collaborating proved difficult remotely, and a lot of time for us has been spent deep in anxiety or trying to prepare for a month of isolation. BUT! it's complete in a sense, it just lacks the "personality" we wanted it to have, and also it doesn't have any sort of menu.

## usage
- open the project in unity, and open the scene "pianoBoy.unity"
  - the plan was to animate a little guy playing the piano
- press the play button
- play some notes on the little keyboard down at the bottom
  - sharps/flats don't work rn
- a bar will pass over the Input Staff to let you know how much longer you have to populate the staff with notes
- once the bar has reached the end, the Output Staff should populate with WFC music, generated based on your input
  - sometimes this doesn't work. If so, restart
  - you can change the parameters of the WFC algorithm by clicking on the gameobject "WFC Overlap" in the hierarcy, and adjusting the variables in the "Overlap WFC (Script)" component
- a bar will pass over the output and play the generated music for a very long time
- if you want to change the speed/tempo, open the "Metronome" gameobject in the hierarchy and change the "bpm" variable in the "Metronome" component

## what we'd like to have
- a little animated guy that plays the piano
- a menu system
- the ability to give the guy feedback, which changes the parameters of the WFC Overlay algorithm
- more of a 'call and response' thing going on
