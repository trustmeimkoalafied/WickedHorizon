INCLUDE globals.ink

Liam! I’m glad you’re okay. #speaker:You #layout:left #audio:celeste_low
-> main

=== main ===
 #speaker:Liam #layout:left #audio:celeste_high
I was s-s-starting to think I’d never see anyone again… besides that scary guy. The chains are really h-heavy. Can you 
let me out?
<i>Clink.</i> #speaker:Chains #audio:beep_3
Oh wow... that feels way better. Ah, your face! You look so hungry, are you o-ok? #speaker:Liam #layout:left #audio:celeste_high
    * [It's all-consuming]
        ~ evilCounter += 1
        If I weren't so focused on escaping, the hunger would be all I could think about. #speaker:You #layout:left #audio:celeste_low
        Wait... I have a granola bar in my pocket still! It's not m-much, but maybe it'll give you some energy. #speaker:Liam #layout:left #audio:celeste_high
            ** [Looks gross]
                ~ evilCounter += 1
                #speaker:You #layout:left #audio:celeste_low
                Thanks... but it doesn't look very appetizing. I'll get a bite to eat after we get out of here without that psycho 
                catching us. 
                Ah, okay. No worries. It has been in my pocket for while. #speaker:Liam #layout:left #audio:celeste_high
                -> note
            ** [Thank you]
                Wow, what a lifesaver. You're always so thoughtful, Liam, thank you. #speaker:You #layout:left #audio:celeste_low
                Hahaha, no problem! #speaker:Liam #layout:left #audio:celeste_high
                -> note
    * [It's not important]
        I was more worried about you. I'll be fine, so don’t worry about me, Liam. #speaker:You #layout:left #audio:celeste_low
        That's a relief. I guess this experience has taken a toll on me, too... #speaker:Liam #layout:left #audio:celeste_high
        -> note

=== note ===
#speaker:Liam #layout:left #audio:celeste_high
Well, you should t-take a look at this. I found this scrap of paper between the couch cushions:
<color=\#FF1E35>“The children wear it like it means something. And it does— to it. It’s how it gets permission to devour</color>
<color=\#FF1E35>them, soul and all.”</color> God, can you imagine being e-e-eaten? What if this thing is real? O-or maybe this guy is a
cannibal? I don't want to die...
    * [That's scary]
        #speaker:You #layout:left #audio:celeste_low
        That does sound really scary. It's going to be okay though, Liam. I'll won't let anything bad happen to you. Come
        with me, okay?
    * [That's bullshit]
        ~ evilCounter += 1
        #speaker:You #layout:left #audio:celeste_low
        Do you believe in the Boogie Man too, Liam? There's no way something like that exists. And we already knew this
        guy was crazy, let's not stick around to see if he takes a bite out of us. You coming?
- Right behind you. I trust you. #speaker:Liam #layout:left #audio:celeste_high
~ liamInteracted = 1
-> END