INCLUDE globals.ink
#speaker:You #layout:left #audio:celeste_low
Keep running! We just have to make it to the edge of the woods.
W-wait! Guys, let's take a break. I really can't r-run anymore. I think we've made it far enough away. #speaker:Liam #layout:left #audio:celeste_high
Ah, okay Liam. Everyone take a breath, he's still small so this is harder on him. #speaker:Alex #layout:left #audio:animal_crossing_mid
#speaker:Jade #layout:left #audio:animal_crossing_high
You're right. Let's stop here for now.
Hmmm... I'd rate that experience pretty low for a team bonding experience, but we made it, at least. I feel like now
    would be the time to finally exchange the friendship bracelets we made. Would that make you feel better, Liam?
#speaker:Liam #layout:left #audio:celeste_high
Hahaha. Maybe. Yes! I worked really hard on mine. You still have them, right?
#speaker:You #layout:left #audio:celeste_low
I do-- Ah! Ah, I'm not-- I'm not feeling... good...
#speaker:!!! #layout:left #audio:animal_crossing_low
<b>YES. THE BRACELETS. YOUR HAND WRAPS AROUND THE FOUR OF THEM, STILL IN YOUR</b>
<b>POCKET. WEAR THEM. FEAST.</b>
Oh my god. Are you okay? What did he do to you? That sick freak! #speaker:Jade #layout:left #audio:animal_crossing_high

// check evil counter. 8 evil choices possible
{evilCounter < 4:
    -> good
    - else:
    -> evil
}

=== good ===
// take out the friendship bracelets... consider them before throwing them away
// reveal you are the creature. Friends react
// you tell your friends to run before you do something you regret
// the hunger kills you
#speaker:!!! #layout:left #audio:animal_crossing_low
<b>YOUR BODY IS STARTING TO EAT ITSELF. THE HUNGER. THE HUNGER IS UNBEARABLE. IT'S TIME TO FINISH WHAT YOU STARTED. DO IT NOW. DO IT NOW. DO ITNOW DOITNOW DOITNOWDOITNOWDOITNOW </b>
    * [Stop yourself.]
        #speaker:!!! #layout:left #audio:animal_crossing_low
        <b>NO. NO! THE HUNGER. IT WILL KILL YOU! YOU HAVE MADE A STUPID CHOICE.</b>
        -> stop
    * [eat?]
        #speaker:You #layout:left #audio:celeste_low
        No.. my friends. My friends. Ah! I can't!
        #speaker:Jade #layout:left #audio:animal_crossing_high
        Hey! Stay with me! Where does it hurt? Please, talk to us!
        #speaker:!!! #layout:left #audio:animal_crossing_low
        <b>WHY WON'T YOU EAT? EAT! EAT OR DIE!</b>
        -> good

=== evil ===
// take out the friendship bracelets... pass them out
// consume.
// the hunger is sated. for now.
#speaker:!!! #layout:left #audio:animal_crossing_low
<b>YOUR BODY IS STARTING TO EAT ITSELF. THE HUNGER. THE HUNGER IS UNBEARABLE. IT'S</b>
<b>TIME TO FINISH WHAT YOU STARTED. DO IT NOW. DO IT NOW. DO ITNOW DOITNOW DOITNOWDOITNOWDOITNOW </b>
    * [FEAST]
        #speaker:!!! #layout:left #audio:animal_crossing_low
        <b>YES! YES! YES!</b>
        -> feast
    * [No! No!]
        #speaker:!!! #layout:left #audio:animal_crossing_low
        <b>WHO DO YOU THINK YOU ARE? YOU'VE KNOWN WHAT YOU WERE GOING TO DO THE</b>
        <b>ENTIRE TIME. YOU ESCAPED THAT BLUBBERING FOOL FOR A SECOND TIME. YOU WILL EAT.</b>
        <b>YOU WILL LIKE IT. </b>
        -> evil
        
=== feast ===
#speaker:You #layout:left #audio:celeste_low
I'm... okay. It was a weird cramp. I think the bracelets are a good idea. Here, one for each of us.
#speaker:Liam #layout:left #audio:celeste_high
Oh... as long as you're o-okay. Yay!!
#speaker:Jade #layout:left #audio:animal_crossing_high
Mine is the best, no offense. See the beads I used?
#speaker:Alex #layout:left #audio:animal_crossing_mid
Yeah, right, check mine out. This is totally better. Hey, Liam? You okay over there? Liam?
#speaker:Liam #layout:left #audio:celeste_high
I
I-I can't move. I can't move. I can't move!
#speaker:Jade #layout:left #audio:animal_crossing_high
I know where we just came from was scary, but you're safe now. You're freaking out. Come here--
What?!
#speaker:Alex #layout:left #audio:animal_crossing_mid
I can't move either. Everything is locking up. This is so... ugh! What is this? Liam, calm down!
#speaker:Liam #layout:left #audio:celeste_high
I CAN'T M-MOVE! I'M N-N-NOT CALM! WHY CAN YOU MOVE? WHAT'S WRONG WITH ME?
#speaker:You #layout:left #audio:celeste_low
..............
#speaker:Jade #layout:left #audio:animal_crossing_high
No. No way. No no no no. Why can you move?
#speaker:You #layout:left #audio:celeste_low
I want you to know... this isn't personal. I can't help what I am. I have to eat. I HAVE to.
#speaker:Alex #layout:left #audio:animal_crossing_mid
No-- go away! Leave us alone! BACK U--
#speaker:FEAST #audio:beep_3
Crunch. Crunch. Snap. Smack.
#speaker:!!! #layout:left #audio:animal_crossing_low
<b>AHHHHH. FOR ALL THE UNPLEASANTRIES, FOR ALL THE SACRIFICE... WHAT A</b>
<b>TERRIFIC MEAL.</b>
-> END


=== stop ===
#speaker:Liam #layout:left #audio:celeste_high
Oh! The b-bracelets! Why did you throw them? I can go grab them--
#speaker:You #layout:left #audio:celeste_low
NO! Liam, no. Don't touch them. Please.
#speaker:Jade #layout:left #audio:animal_crossing_high
.............
#speaker:Alex #layout:left #audio:animal_crossing_mid
What's going on with you? Where are you hurt? You're curling up in pain.
#speaker:You #layout:left #audio:celeste_low
Leave. Now. Please don't ask me anything else. I'm-- I'm not what you think I am.
#speaker:Liam #layout:left #audio:celeste_high
I-I'm scared. Someone should run the rest of the way and g-g-get a doctor. Or--
#speaker:Jade #layout:left #audio:animal_crossing_high
Liam. Quiet, please.
You... that crazy guy was telling the truth? That one of us is a... a monster?
#speaker:You #layout:left #audio:celeste_low
Please. I'm sorry. I can't help what I am. But I don't want to hurt you. When I was looking for you all in that house...
I was so scared. I've never felt that way. I'm tired of living like this. But you need to go before I--
#speaker:Jade #layout:left #audio:animal_crossing_high
Right. Liam. Alex. We have to run again. Don't look back. Actually, Alex, grab Liam.
#speaker:Alex #layout:left #audio:animal_crossing_mid
This is insane. Liam, stop fighting. Let's go! Now!
#speaker:!!! #layout:left #audio:animal_crossing_low
<b>WHERE HAS THIS LEFT YOU, FOOL? HUNGRY. STARVING! AND ALONE. YOU WILL DIE</b>
<b>NOW, DO YOU REALIZE THAT?</b>
#speaker:You #layout:left #audio:celeste_low
I know. I know. But I've... hurt so many people. So many who called me friend. And I'm so tired. I want to sleep now.
-> END