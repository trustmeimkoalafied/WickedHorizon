INCLUDE globals.ink

Oh my goodness Jade! Are you okay? #speaker:You #layout:left #audio:celeste_low
-> main

=== main ===
I think so! I'm just uncomfortable in these chains. Help a girl out? #speaker:Jade #layout:left #audio:animal_crossing_high
<i>Clink.</i> #speaker:Chains #audio:beep_3
Ah! Thank you. God, I hate crazy people. And this crazy ugly house. I was so bored sitting here I ripped this #speaker:Jade #layout:left #audio:animal_crossing_high
article off the wall and read the whole thing. It's super creepy, you should hear it.
    * [Alright]
        Go ahead, I'm listening. #speaker:You #layout:left #audio:celeste_low
        Okay, here it is: #speaker:Jade #layout:left #audio:animal_crossing_high
        -> note
    * [Ignore it]
        ~ evilCounter += 1
        Who cares about some random paper? You're out now, we should get moving. #speaker:You #layout:left #audio:celeste_low
        That creep kept it for a reason! Just listen: #speaker:Jade #layout:left #audio:animal_crossing_high
        -> note

=== note ===
October 24, 2000 #speaker:Jade #layout:left #audio:animal_crossing_high
<b>Local Boy Russell Still Missing</b>
Community members are left on edge after the disappearance of 12-year old Russel Stewart.
    A lack of leads has left authorities shaken. Friends last saw Russel at a local park near the woods, but he
    never returned home. A close friend of the missing boy claims to have witnessed a strange figure near the
    woods on the day of the disappearance, though authorities could not substantiate his claims.
    <color=\#FF1E35>“It's out there,”</color> his friend was quoted as saying. <color=\#FF1E35>“And one day, it'll <b>pay</b> for what it did to Russel.”</color>
    * [It's in the past]
        ~ evilCounter += 1
        Wow this article is 24 years old, why does this maniac have this? #speaker:You #layout:left #audio:celeste_low
        He must think one of us is this.. creature he saw. He wouldn't stop asking me if I was hungry. #speaker:Jade #layout:left #audio:animal_crossing_high
        Who cares what he believes? We need to escape, and that's all. #speaker:You #layout:left #audio:celeste_low
    * [He lost a friend]
        That must've been his friend... I see why he lost his mind. #speaker:You #layout:left #audio:celeste_low
        That's what I think! Maybe we could reason with him. We're just kids. We had nothing to do with this. #speaker:Jade #layout:left #audio:animal_crossing_high
            ** [Too far gone]
                ~ evilCounter += 1
                Look around, Jade. He's not above kidnapping, who knows what else he'll do? Let's go. #speaker:You #layout:left #audio:celeste_low
            ** [Maybe]
                Jade... I don't know. We can try if that's what it comes down to. Let's focus on getting out without getting caught. #speaker:You #layout:left #audio:celeste_low
- Ok... we can do this. Keep your head on a swivel, I think I hear him walking around somewhere.#speaker:Jade #layout:left #audio:animal_crossing_high
~ jadeInteracted = 1
-> END