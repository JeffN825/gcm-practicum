# GCM Practicum

# Summary

The Gcm.Practicum solution (located at Gcm.Practicum\Gcm.Practicum.sln) is in Visual Studio 2013 format. It consists of projects: Gcm.Practicum.Console, Gcm.Practicum.Services and Gcm.Practicum.Tests.

# Gcm.Practicum.Console

This project compiles to a console executable which exposes service level functionality.

# Gcm.Practicum.Services

This project contains services that perform business domain operations.

# Gcm.Practicum.Tests

This project contains unit tests.

# Build

Double click on Gcm.Practicum\Build.bat to build the solution and run all unit tests in it. This batch file invokes msbuild.exe on Build.proj which

- Cleans and builds Gcm.Practicum.sln
- Runs MSTest on all *.Tests.dll files in all subdirectories under all bin subdirectories under the solution directory.