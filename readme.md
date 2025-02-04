# One Tap Army Clone

## Development Report
### Day 1
- To work more efficiently, write down the necessary mechanics on paper.
- Import neccessary assets. DOTween, Unitask, NaughtAttributes, Custom Toolbar, ColoredHierarchy, Particle Effects For UGUI(In any case), (My customized version), FormatableText (My own creation)
- Determine the starting point. It was towers.
- Create functional tower mechanics. Level, model, health, basic spawn logic.
- While working on tower spawn bar, I encountered a problem with Dotween and Unitask that took an hour to resolve. Even if I added "UNITASK_DOTWEEN_SUPPORT" to scripting define symbols I couldn't access "ToUniTask()" function from dotween tweeners. After some debugging, researching and restarting Unity I was still unable to fix it. The issue was resolved only after deleting and reimporting both dotween and unitask.