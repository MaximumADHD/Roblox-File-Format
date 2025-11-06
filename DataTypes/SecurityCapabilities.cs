using System;
using RobloxFiles.Enums;

// TODO: This should use a source generator.

namespace RobloxFiles
{
    [Flags]
    public enum SecurityCapabilities : ulong
    {
        RunClientScript 
            = 1u << SecurityCapability.RunClientScript,

        RunServerScript
            = 1u << SecurityCapability.RunServerScript,

        AccessOutsideWrite
            = 1u << SecurityCapability.AccessOutsideWrite,

        AssetRequire
            = 1u << SecurityCapability.AssetRequire,

        LoadString
            = 1u << SecurityCapability.LoadString,

        ScriptGlobals
            = 1u << SecurityCapability.ScriptGlobals,

        CreateInstances
            = 1u << SecurityCapability.CreateInstances,

        Basic
            = 1u << SecurityCapability.Basic,

        Audio
            = 1u << SecurityCapability.Audio,

        DataStore
            = 1u << SecurityCapability.DataStore,

        Network
            = 1u << SecurityCapability.Network,

        Physics
            = 1u << SecurityCapability.Physics,

        UI
            = 1u << SecurityCapability.UI,

        CSG
            = 1u << SecurityCapability.CSG,

        Chat
            = 1u << SecurityCapability.Chat,

        Animation
            = 1u << SecurityCapability.Animation,

        Avatar
            = 1u << SecurityCapability.Avatar,

        Input
            = 1u << SecurityCapability.Input,

        Environment
            = 1u << SecurityCapability.Environment,

        RemoteEvent
            = 1u << SecurityCapability.RemoteEvent,

        LegacySound
            = 1u << SecurityCapability.LegacySound,

        Players
            = 1u << SecurityCapability.Players,

        CapabilityControl
            = 1u << SecurityCapability.CapabilityControl,

        Plugin
            = 1u << SecurityCapability.Plugin,

        LocalUser
            = 1u << SecurityCapability.LocalUser,

        WritePlayer
            = 1u << SecurityCapability.WritePlayer,

        RobloxScript
            = 1u << SecurityCapability.RobloxScript,

        RobloxEngine 
            = 1u << SecurityCapability.RobloxEngine,

        Unassigned
            = 1u << SecurityCapability.Unassigned,

        InternalTest 
            = 1u << SecurityCapability.InternalTest,

        PluginOrOpenCloud
            = 1u << SecurityCapability.PluginOrOpenCloud,

        Assistant 
            = 1u << SecurityCapability.Assistant,

        RemoteCommand
            = 1u << SecurityCapability.RemoteCommand,
    }
}
