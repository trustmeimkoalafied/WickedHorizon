INCLUDE globals.ink

Alex! You’re alright. Let’s get out of here. #speaker:You #layout:left #audio:celeste_low
-> main

=== main ===
#speaker:Alex #layout:left #audio:animal_crossing_mid
Yeah… yeah, I guess I am. For a minute there I thought he would hurt me. He seems so convinced that one
of us is a monster. He used these silver chains to lock me up and seemed surprised I didn't start to burn.
I'm just glad you're here now. Could you help me out?
<i>Clink.</i> #speaker:Chains #audio:beep_3
Thanks... Oh god, what happened to your wrists? #speaker:Alex #layout:left #audio:animal_crossing_mid
    * [Reassure him]
        #speaker:You #layout:left #audio:celeste_low
        He put my cuffs on really tight and now they're sore. I'm glad he didn't hurt you Alex. We're going to find a way out,
        together.
        We have to get you some ointment after we escape. Thank you for coming to get me. #speaker:Alex #layout:left #audio:animal_crossing_mid
        -> note
    * [Reprimand him]
        ~ evilCounter += 1
        #speaker:You #layout:left #audio:celeste_low
        How about you grill me about what this psycho did to me later? Good for you that nothing happened, but I wasn't so
        lucky.
        I'm sorry, I really didn't mean it like that. #speaker:Alex #layout:left #audio:animal_crossing_mid
        -> note

=== note ===
Hey, I did find this weird note under the tub: #speaker:Alex #layout:left #audio:animal_crossing_mid
<color=\#FF1E35>“It is clever, it has learned to hide among them, mimicking their every move. I cannot let it</color>
<color=\#FF1E35>continue, not when I am so close-I will be ready.”</color>
    * [Consider it]
        #speaker:You #layout:left #audio:celeste_low
        Sounds like he is chasing something he doesn’t fully understand. Regardless, we have to keep moving,
        we’ll be out of here soon.
    * [Blow it off]
        ~ evilCounter += 1
        Are we listening to crazy people and their rants now? We're wasting time when we could be leaving. Let's go. #speaker:You #layout:left #audio:celeste_low
- Alright… I’ll follow you, but… let’s be careful.
~ alexInteracted = 1
-> checks

=== checks ===
YOUR CURRENT EVIL LEVEL: {evilCounter} #speaker:Alex #layout:left #audio:animal_crossing_mid
YOUR CURRENT ALEX VARIABLE: {alexInteracted}
-> END