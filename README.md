# VB-FORM-VS-IDE-TEST-1

A disposable experiment to test whether a Visual Basic .NET Windows Forms application can be created, built, tested, and packaged by GitHub Actions without using the Visual Studio IDE on the developer's computer.

## Goal

Use GitHub as the source of truth and a Windows-hosted workflow as the build machine.

- Keep the VB.NET source code in this repository.
- Build the Windows Forms application with the .NET SDK on GitHub Actions.
- Publish a downloadable Windows x64 executable as a workflow artifact.
- Use workflow logs and build status to verify each step.

## Project

- Language: Visual Basic .NET
- UI: Windows Forms
- Target framework: .NET 8 for Windows
- Build environment: GitHub Actions on `windows-latest`
- IDE requirement on the developer's computer: None for the automated build

This experiment does **not** claim that Windows Forms can run natively on Linux, Android, or in a web browser. The Windows Forms application runs on Windows. GitHub's Windows runner compiles and packages it remotely.

## Run the workflow

1. Open the **Actions** tab in this repository.
2. Select **Build VB.NET Windows Forms**.
3. Choose **Run workflow** to start it manually, or push a change to the `main` branch.
4. Open the completed run and inspect the build/publish logs.
5. Download the `VB-FORM-VS-IDE-TEST-1-win-x64` artifact.

The workflow also runs for pull requests targeting `main`.

## Current milestone

**Milestone 1 — Minimal application and automated Windows build.**

Success criteria:
- [ ] Workflow starts successfully.
- [ ] .NET restore and Release build pass.
- [ ] Self-contained Windows x64 publish succeeds.
- [ ] Downloadable artifact is attached to the workflow run.
- [ ] The executable is downloaded and tested on a Windows PC.

## Important notes

- The workflow builds the source committed to this repository; it does not magically generate arbitrary applications from a plain-language request yet.
- Self-contained publishing bundles the .NET runtime with the app, but the output is still a Windows application and must be tested on Windows.
- This repository is an experiment. Do not store secrets, signing keys, or personal data in source control.
