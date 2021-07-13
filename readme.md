# readme

## Purpose

This converts Nintenlord's NUPS Patcher to dotnet core so it can be run on Linux.
Only applying a patch is supported, not creating or inspecting.
Original readme is at `original_readme.txt`.

## Usage

the simplest usage is to move a .ups and .gba file to the project directory.

Then run:

```sh
dotnet run
```

## Output

Unlike the original, no files are overwritten.  A `{game_name}_patched.gba` file will be written to the current directory.