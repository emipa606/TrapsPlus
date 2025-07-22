# .github/copilot-instructions.md

## RimWorld Mod: Traps Plus

### Mod Overview and Purpose
The "Traps Plus" mod for RimWorld introduces a variety of custom traps to enhance base defense strategies. Each trap has unique characteristics and employs different mechanisms to deter, injure, or incapacitate enemies. This mod aims to provide players with creative and strategic options when defending against raids and threats in their colonies.

### Key Features and Systems
- **Diverse Trap Types:**
  - **Building_BearTrap:** A mechanical trap that immobilizes and damages enemies.
  - **Building_BodyCrusherTrap:** A heavy-duty trap designed to crush intruders.
  - **Building_BodySlicerTrap:** Utilizes sharp blades to slice enemies.
  - **Building_CaltropsTrap:** Deploys spiked objects on the ground to impair movement.
  - **Building_FreezePadTrap:** Emits freezing temperatures to slow down and harm.
  - **Building_HeatPadTrap:** Creates intense heat to burn and damage.
  - **Building_SawsTrap:** A rotating saw that cuts through intruders.
  - **Building_SpikesTrap:** Uses spikes to impale enemies.

- **Hediff Management:**
  - The `HediffDefOfTrap` class is used to manage and define injuries or conditions (Hediffs) applied by traps.

### Coding Patterns and Conventions
- **Class Naming:** Classes are prefixed with `Building_` to indicate they are structures within the game, following the base structure from RimWorld’s development pattern.
- **Method Naming:** The convention of using camelCase is followed, e.g., `DamagePawn`, to denote private methods within classes.
- **Inheritance:** Trap classes typically inherit from either `Building_TrapRearmable` or `Building_Trap`, capturing reusable architecture from the base game's implementation.

### XML Integration
- XML integration is generally done to define traps' properties such as damage amount, rearm time, graphic representation, and other gameplay elements.
- Ensure that each trap has its corresponding XML definition to properly instantiate in the game environment.

### Harmony Patching
- **Usage:** Harmony is utilized to modify or extend the game's assembly without directly altering the RimWorld code.
- Consider using Harmony to intercept methods if modifications to core behaviors are necessary, such as altering how traps trigger or apply effects to pawns.
- Always utilize prefixes and postfixes within Harmony patches to safely manage game functionality.

### Suggestions for Copilot
- **Method Suggestions:** Provide code snippets for calculating damage or rearm times dynamically based on trap type.
- **XML Generation:** Assist with the generation of XML configuration files for new traps, including necessary attributes like `damage`, `cost`, and `durability`.
- **Patching Examples:** Supply examples of Harmony patches, demonstrating their application to trap triggering methods.
- **Code Optimization:** Suggest refactorings to improve performance, particularly when handling repeated operations or calculations in `DamagePawn`.
- **Documentation Aids:** Provide automated documentation comments to ensure methods and classes are well-described.

By adhering to these guidelines and suggestions, developers and Copilot can collaboratively maintain, extend, and improve the Traps Plus mod to ensure high-quality and engaging gameplay experiences for RimWorld players.
