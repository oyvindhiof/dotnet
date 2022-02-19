using System;

namespace ComicsUniverse.ViewModels
{
    [Flags]
    public enum Universes
    {
        Unknown = 0b_0000_0000,  // 0
        DC = 0b_0000_0001,  // 1
        Marvel = 0b_0000_0010,  // 2
        All = DC | Marvel    // 3
    }
}
