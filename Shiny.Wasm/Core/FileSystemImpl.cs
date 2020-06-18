using System;
using System.IO;

using Shiny.IO;


namespace Shiny.Wasm.Core
{
    // This has no business here
    public class FileSystemImpl : IFileSystem
    {
        public DirectoryInfo AppData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DirectoryInfo Cache { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DirectoryInfo Public { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
