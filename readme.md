# One Tap Army Clone

## 3rd Party Assets
- Dotween
- Unitask
- NaughtyAttributes
- UnityToolbarExtender
- CustomPlayButton
- Particle Effects For UGUI
- FormatableText (My own creation)
- ColoredHierarchy (My customized version)

## Development Report
### Day 1
- To work more efficiently, write down the necessary mechanics on paper.
- Import neccessary assets.
- Determine the starting point. It was towers.
- Create functional tower mechanics. Level, model, health, basic spawn logic.
- While working on tower spawn bar, I encountered a problem with Dotween and Unitask that took an hour to resolve. Even if I added "UNITASK_DOTWEEN_SUPPORT" to scripting define symbols I couldn't access "ToUniTask()" function from dotween tweeners. After some debugging, researching and restarting Unity I was still unable to fix it. The issue was resolved only after deleting and reimporting both dotween and unitask.

### Day 2
- Started a day with a day planning. The plan was starting with the xp bar for the player. Then start to soldiers, soldier cards and upgrade cards. But things didn't go as planned.
- XP bar, main menu, level selection and settings panels are completed for basic testing.
- Soldiers, cards and other AI mechanics left for tomorrow.

### Day 3
- Started with basic planning. Plan was first creating soldier prefabs then move and attack logic. After that add soldier cards. 
- After thinking about how to implement soldiers I though it might be better starting with soldier cards. But before started there is something that I don't like about starting the game. Selecting unit type from start of the game. I want to change it to with deck sytem. Players have decks. When progressing the game player unlocks more unit types and it will give player a progress feeling. 
- Then I started soldier prefabs. Thing got bad after that. I got sick and I cannot do anything about 3-4 hours. After some rest, I feel better but it was a bit painfully.
- I have implement soldier movements, very basic state machine. Then I call it a day.
- Soldiers still not attacking, there is no win-lose panels, no level up card selections, no sounds and no effect.
- I will try to do my best complete it tomorrow but I have no hope that I will make it tomorrow night with this sickness and this much work to do.

### Day 4
- Started the day with the false hope of finishing the project tonight.
- Some wrong decision make a snowball effect, they made the project increasingly difficult to manage. Still, I try my best to complete as much as I can.
- I made a list, write down all missing pieces. These were: Level up cards, soldier attacks, sounds and effects.
- I initially tought soldier attack system would take quite long to implement and sounds and effects would be pointless if the game wasn't finished complately. So, I decided to focus on level up cards.
- While working on this, it was to hard to progress because the project became too messy and it was too painfully to implement new mechanics.


## Lessons Learned
- Planning ahead is crucial--spend at least 1/3 of the time on planning. Think multiple possible outcomes and potential problems.
- Rushing into features without thinking about the overall structure can create long-term problems.
- Don't underestimate mechanics. Analyze each feature carefully before implementation.
- Prioritize the most critical ones first.
