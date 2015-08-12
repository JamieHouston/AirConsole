using System;
using ObjCRuntime;

[assembly: LinkWith ("libAirconsole.a", LinkTarget.ArmV7 | LinkTarget.Arm64 |LinkTarget.Simulator, SmartLink = true, ForceLoad = true)]
