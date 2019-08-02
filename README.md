# Cicada (TBD)
The codebase for cicada-like kinetic sculptures that communicate with eachother with the sound produced by their "wings".

## Physical construction
    The cicada project will consist of 2+ individual cicadas, each of which is a sculpture about 2.5ft by 3ft. Each cicada will have two wings, a head, and an abdomen.
        The wings of the Cicada will consist of two folding nylon fans driven by actuators or motors. Each wing will have a strip of rgb LEDS that will backlight the fans when they are open. The fan wings will open and close to make a series of loud "BRRAPPING" noises in variable patterns.
        The abdomen of the cicaida will have a series LEDs surrounding it's base similar to a firefly. The abdomen will contain the microcontroller and power supply. The middle of abdomen will contain a mechanism to secure the cicaida to a tree.
        The head of the Cicada will have microphones to hear other cicaidas as well as cameras/distance sensor aiming outwards away from the tree they are mounted to.

## Behavior
    Each Cicaida will listen for a variable period of time for other cicadas and then will generate a pseudorandom pattern of wingbeats if it does not hear anything and does not have any pattern stored already. If the cicada does hear something it will assess whether the sound is a wingbeat of another cicada, or just noise. If the sound is found to be noise, or the cicada does not hear anything, the cicada will repeat the previous pattern again, until it gets a response. If the sound is found to be another cicada, it will attempt to copy the detected wingbeats, adding one of it's own wingbeats to the end of the sequence. If there are more than 9 wingbeats already in the sequence, the cicada will drop the first wingbeat before adding their own. if the proximity sensor exceeds a certain threshold, indicating that someone has approached the cicaida, the cicaida will stop generating wingbeats until the person exceeds the threshold. In this time, it will slowly open its wings in a random breating pattern and pulse it's leds. when the coast is clear, the cicada will repeat the last stored pattern.