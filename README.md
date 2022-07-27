# Unilog

> DANGER! Work in progress!

## How to use

```csharp
// Mute every log until Unmute is called
Unilog.Mute();

// Mute every Debug message with LogLevel.Debug
Unilog.Mute(LogLevel.Debug);

// Unmute log level
Unilog.Unmute(LogLevel.Debug).Debug("Unmuted debug");

// Mute every message with tag "test"
Unilog.Mute("test");

// Unmute
Unilog.Unmute("test");

// Different levels of logging
Unilog.Debug("Message");
Unilog.Info("Message");
Unilog.Log("Message");
Unilog.Warning("Message");
Unilog.Error("Message");

// Optional chaining
Unilog.Mute("Test").Mute(LogLevel.Info).Mute(LogLevel.Warning).Debug("Debug message", 1, 2, 2.3);

// Yu can add KeyValue
Unilog.KeyValue("key", 1).KeyValue("key2", "Name").Debug("test");

// KV also could be added globally
Unilog.KeyValueGlobal("service", "game");

```
