using System;
using RobloxFiles.Enums;

namespace RobloxFiles
{
    [Flags]
    public enum SecurityCapabilities : ulong
    {
        RunClientScript 
            = 1 << SecurityCapability.RunClientScript,

        RunServerScript
            = 1 << SecurityCapability.RunServerScript,

        AccessOutsideWrite
            = 1 << SecurityCapability.AccessOutsideWrite,

        AssetRequire
            = 1 << SecurityCapability.AssetRequire,

        LoadString
            = 1 << SecurityCapability.LoadString,

        ScriptGlobals
            = 1 << SecurityCapability.ScriptGlobals,

        CreateInstances
            = 1 << SecurityCapability.CreateInstances,

        Basic
            = 1 << SecurityCapability.Basic,

        Audio
            = 1 << SecurityCapability.Audio,

        DataStore
            = 1 << SecurityCapability.DataStore,

        Network
            = 1 << SecurityCapability.Network,

        Physics
            = 1 << SecurityCapability.Physics,

        UI
            = 1 << SecurityCapability.UI,

        CSG
            = 1 << SecurityCapability.CSG,

        Chat
            = 1 << SecurityCapability.Chat,

        Animation
            = 1 << SecurityCapability.Animation,

        Avatar
            = 1 << SecurityCapability.Avatar,

        Input
            = 1 << SecurityCapability.Input,

        Environment
            = 1 << SecurityCapability.Environment,

        RemoteEvent
            = 1 << SecurityCapability.RemoteEvent,

        LegacySound
            = 1 << SecurityCapability.LegacySound,

        Players
            = 1 << SecurityCapability.Players,
    }
}
