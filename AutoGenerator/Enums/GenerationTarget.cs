namespace AutoGenerator.Enums
{

    using System;

    [Flags]
    public enum GenerationTarget
    {
        None = 0,
        ApiClient = 1 << 0,  // 1
        Repository = 1 << 1,   // 2
        UseCase = 1 << 2,     // 4
        Service = 1 << 3,     // 8
        Template = 1 << 4,    // 16
        Component = 1 << 5,    // 32
        All = ApiClient | Repository | UseCase | Service | Template | Component // 1 + 2 + 4 + 8 + 16 + 32 = 63
    }

}
