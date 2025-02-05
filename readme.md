# One Tap Army Clone

## Development Report
### Day 1
- To work more efficiently, write down the necessary mechanics on paper.
- Import neccessary assets. DOTween, Unitask, NaughtAttributes, Custom Toolbar, ColoredHierarchy, Particle Effects For UGUI(In any case), (My customized version), FormatableText (My own creation)
- Determine the starting point. It was towers.
- Create functional tower mechanics. Level, model, health, basic spawn logic.
- While working on tower spawn bar, I encountered a problem with Dotween and Unitask that took an hour to resolve. Even if I added "UNITASK_DOTWEEN_SUPPORT" to scripting define symbols I couldn't access "ToUniTask()" function from dotween tweeners. After some debugging, researching and restarting Unity I was still unable to fix it. The issue was resolved only after deleting and reimporting both dotween and unitask.

### Day 2
- Started a day with a day planning. The plan was starting with the xp bar for the player. Then start to soldiers, soldier cards and upgrade cards. But things didn't go as planned.
- XP bar, main menu, level selection and settings panels are completed for basic testing.
- Soldiers, cards and other AI mechanics left for tomorrow.