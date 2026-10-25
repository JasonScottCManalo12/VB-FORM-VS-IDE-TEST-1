# VB-FORM-VS-IDE-TEST-1

> **README timestamp:** 2026-10-26 00:59:59 PHT (UTC+08:00)

A workflow-based experiment to build and package a Visual Basic .NET Windows Forms application without opening the Visual Studio IDE on the developer's computer.

## Goal

Use GitHub as the source of truth and a Windows-hosted GitHub Actions runner as the build machine.

- Keep the VB.NET source code in this repository.
- Restore, build, and publish the application remotely.
- Package the Windows x64 app as both a self-contained executable and a Windows Installer `.msi` package.
- Verify each stage using workflow logs and uploaded artifacts.

## Project

- Language: Visual Basic .NET
- UI: Windows Forms
- Target framework: .NET 8 for Windows
- Build environment: GitHub Actions on `windows-latest`
- Installer technology: WiX Toolset 4
- Developer PC requirement for automated builds: No Visual Studio IDE required

This application is Windows-only. It does **not** run natively as a Windows Forms app on Linux, Android, or in a web browser. GitHub's Windows runner builds and packages it remotely.

## Run the workflow

1. Open the [Actions tab](https://github.com/JasonScottCManalo12/VB-FORM-VS-IDE-TEST-1/actions).
2. Select **Build VB.NET Windows Forms**.
3. Choose **Run workflow**, or push a change to `main`.
4. Open the completed run and inspect the build, publish, and MSI packaging logs.
5. Download the artifact you need.

The workflow uploads two artifacts:

- `VB-FORM-VS-IDE-TEST-1-win-x64` — published application files.
- `VB-FORM-VS-IDE-TEST-1-msi` — Windows Installer package.

The workflow also runs for pull requests targeting `main`.

## Automated GitHub Releases

Pushing a version tag that starts with `v` (for example, `v0.1.0`) triggers the same Windows build. If the build and MSI packaging succeed, a second job creates a GitHub Release and attaches these direct downloads:

- `VB-FORM-VS-IDE-TEST-1.exe` — self-contained Windows x64 application.
- `VB-FORM-VS-IDE-TEST-1.msi` — Windows installer.

Ordinary pushes to `main`, pull requests, and manual workflow runs do **not** publish a release. Releases are created only from version tags. The release job has write permission only for publishing the release; the build job retains read-only repository permissions.

To make a release, create and push a version tag such as `v0.1.0` from the commit you want to ship. Monitor the [Actions tab](https://github.com/JasonScottCManalo12/VB-FORM-VS-IDE-TEST-1/actions); when both jobs succeed, the release will appear on the [Releases page](https://github.com/JasonScottCManalo12/VB-FORM-VS-IDE-TEST-1/releases).

## MSI installer behavior

The WiX installer is configured for 64-bit Windows and per-machine installation. It installs the self-contained application executable under Program Files. Windows may request administrator approval. The MSI uses a stable UpgradeCode to support future major-version upgrades when the package version is incremented.

The current installer is a minimal proof of concept: it installs the app executable but does not yet create a Start Menu or desktop shortcut. The MSI must be tested on a Windows PC before it is considered production-ready.

## Milestones

### Milestone 1 — Minimal app and automated Windows build

- [x] Workflow starts successfully.
- [x] .NET restore and Release build pass.
- [x] Self-contained Windows x64 publish succeeds.
- [x] A downloadable executable artifact is produced.
- [ ] Download and test the executable on a Windows PC.

### Milestone 2 — MSI packaging

- [x] Add a WiX installer definition.
- [x] Add an automated MSI packaging step.
- [x] Configure an MSI artifact upload.
- [ ] Confirm the GitHub Actions workflow completes successfully with the MSI step.
- [ ] Download and test MSI installation and uninstallation on a Windows PC.

## Important notes

- The workflow builds the source committed to this repository; it does not yet generate arbitrary applications from plain-language requests.
- Self-contained publishing bundles the .NET runtime with the app, but the result is still a Windows application.
- The MSI is not digitally signed in this experiment, so Windows SmartScreen or security software may display warnings.
- Do not store secrets, signing keys, or personal data in source control.
