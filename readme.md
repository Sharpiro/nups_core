# readme

## Purpose

This converts Nintenlord's NUPS Patcher to dotnet core so it can be run on Mac and Linux.
Only applying a patch is supported, not creating or inspecting.
Original readme is at `original_readme.txt`.

## Downloading

See [releaes](https://github.com/Sharpiro/nups_core/releases) to download a build for your machine

## Usage

### no args

the simplest usage is to move a .ups and .gba file with the same name to the program directory.

```sh
./nups_patcher
```

### provide ups file path

If there is more than 1 `.ups` file in the working directory, you can specify which you want to use.
The program will then expect an identically named `.gba` file in the same directory.

```sh
./nups_patcher path/to/file.ups
```

### provide ups and gba file path

if the `.gba` file is named differently than the `.ups` file, you can specify it as well.

```sh
./nups_patcher path/to/file.ups path/to/file.gba
```

## Output

Unlike the original patching program, no input files are overwritten.
A `{patch_name}_patched.gba` file will be written to the working directory.
If run multiple times, the created patched file will be overwritten

## Building

### Prerequisites

- dotnet core
- ability to build with 3.1 SDK

### Build all platforms

artifacts will be built in `publish` directory

```sh
./publish.sh
```
