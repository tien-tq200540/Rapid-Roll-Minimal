# \# Rapid-Roll-Minimal

# 

# A mini-project remaking the classic \*Rapid Roll\* game from retro Nokia devices, built in \*\*3 days\*\* to practice fundamental Unity features and basic clean code principles.

# 

# \## 🛠️ Engine Version \& Platform

# \* \*\*Unity Version:\*\* LTS 2022.3.62f2

# \* \*\*Platform:\*\* PC / WebGL (Designed for Portrait 9:16 Aspect Ratio)

# 

# \## 📌 Features Applied (What I Practiced)

# Instead of over-engineering, this project focuses on successfully applying core Unity and C# concepts to solve practical game-loop problems:

# \* \*\*Input System:\*\* Integrated the \*\*New Input System\*\* using standard `A/D` or `Arrow Keys` for ball movement.

# \* \*\*Basic Memory Reuse:\*\* Implemented a simplified \*\*Object Pooling\*\* mechanism to recycle platforms, avoiding constant Instantiate/Destroy lag.

# \* \*\*C# Actions \& Events:\*\* Used standard C# `Action` to send updates (Score, Health, High Score triggers) from gameplay components to a central `GameManager`, practicing basic decoupled communication between Logic and UI.

# \* \*\*Asynchronous UI Effects:\*\* Used \*\*Coroutines\*\* combined with `WaitForSecondsRealtime` to handle UI text flashing smoothly, even when `Time.timeScale = 0` (Game Over).

# \* \*\*Data Persistence:\*\* Saved and loaded high scores using `PlayerPrefs` with string conversion to support the `long` data type.

# 

# \## 🎮 How to Play

# \* Use `A/D` or `Left/Right Arrow` keys to steer the ball.

# \* Stay on the platforms, dodge spikes, and survive as long as possible!

# 

# \## 💡 What I Learned \& Next Steps

# \* \*\*Core Life-cycles:\*\* Better understood how Unity's `OnEnable`, `OnDisable`, and UI Canvas components interact during initialization.

# \* \*\*Next to Learn:\*\* Deepen my understanding of architectural patterns (like a fully abstract Observer Pattern or Event Manager) to scale up larger projects in the future.

#

# \## Demo link

# \* \*\*PC:

# \* \*\*WebGL:

