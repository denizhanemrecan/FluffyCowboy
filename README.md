# Fluffy Cowboy

A rhythm-based shooter made in Unity during the **BUG Summer GameJam 2022** at Bahçeşehir University. Shoot on the beat, swipe to dodge, and survive waves of cactus enemies.

**Play it in the browser:** [denizhanemrecan.itch.io](https://denizhanemrecan.itch.io)

## Architecture highlights

- **Rhythm system** — `NoteProducer` spawns notes from the music timeline, `NoteManager` tracks timing windows, `Note` handles hit/miss evaluation
- **Input** — `SwipeManager` turns touch and mouse gestures into gameplay actions
- **Combat** — `EnemyBase` with behaviour components and projectiles; `PlayerShoot` ties firing to the beat
- **Services** — `ManagerProvider` as a central access point for managers; `AudioManager` for music and SFX playback
- **Flow** — cutscene controller, level selection, pause and end-game screens

## Team

Built as a team during the jam; I was one of the main programmers on the project.

## Notes

Third-party effect assets were removed from this public copy for licensing reasons, so some particle effects will be missing when opening the project. Built end to end within the jam timeframe, so the code favors speed over polish.