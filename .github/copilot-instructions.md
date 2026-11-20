# GitHub Copilot Instructions for Traps Plus (Continued) Mod

## Mod Overview and Purpose

**Traps Plus (Continued)** is a RimWorld mod that aims to enhance the gameplay experience by adding new, improved, and versatile traps to the game. The mod focuses on providing higher-quality textures and allowing players to select between new and old textures for a more personalized experience.

## Key Features and Systems

- **Higher Quality Textures:** The mod includes enhanced textures for all traps, thanks to Jabbamonkey's contributions. Players can toggle between new and old textures by rotating the trap before placing it.
- **Additional Traps:** The mod adds several new traps to the game, including:
  - Bear Trap (Rearmable)
  - Spikes
  - Caltrops
  - Body Crusher (Rearmable)
  - Body Slicer (Rearmable)
  - Heat Pad (Powered)
  - Freeze Pad (Powered)
  - Saws (Powered)
- **Modular Design:** The mod is designed to be easily expandable, with plans to add more traps in the future.

## Coding Patterns and Conventions

- **Consistent Naming Conventions:** Use PascalCase for class names and methods, and camelCase for local variables and parameters.
- **Code Organization:** Maintain a clean and organized codebase by grouping related classes and methods together.
- **Documentation:** Provide clear comments and documentation for complex logic and methods to ensure maintainability.

## XML Integration

- **Def Files:** The mod uses XML files to define new game elements such as traps and their properties.
- **Patch Files:** The mod utilizes XML patch files to modify existing game mechanics and integrate new traps seamlessly.

## Harmony Patching

- **Harmony Patches:** Use Harmony patching to modify existing game code without altering the original source files. This ensures compatibility with future game updates.
- **Patch Naming Conventions:** Name patch methods and classes clearly to indicate their purpose and impact on the game.

## Suggestions for Copilot

- **Code Templates:** Provide code templates for new traps and classes to streamline the development process.
- **XML Snippets:** Include XML snippets for defining new game elements and patches to save time and reduce errors.
- **Example Patches:** Share example Harmony patches for modifying game behavior, such as adjusting trap mechanics or adding new features.
- **Texture Guidelines:** Provide guidelines and best practices for creating and integrating high-quality textures for new traps.

## Additional Information

- **Dependencies:** Ensure that the mod is compatible with the following dependencies:
  - Dorely.BetaTraps
  - UnlimitedHugs.HugsLib
- **Error Reporting:** If you encounter any issues, please report them using the Discord channel or the GitHub repository, following the provided guidelines.

By following these instructions, developers can contribute effectively to the Traps Plus (Continued) mod and help enhance the RimWorld experience for players worldwide.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

