namespace Day07
{
    internal class MyDirectory
    {
        public MyDirectory Parent { get; init; }

        public string Name { get; init; }

        public string Path => Parent?.Path + Name + "/";

        public int Size => Files.Values.Sum(x => x.Size) + Subdirectories.Values.Sum(x => x.Size);

        public Dictionary<string, MyDirectory> Subdirectories { get; } = new();

        public Dictionary<string, MyFile> Files { get; } = new();

        public List<MyDirectory> GetAllSubdirectoriesLowerThan(int maxSize)
        {
            var result = new List<MyDirectory>();
            foreach (var dir in Subdirectories.Values)
            {
                if (dir.Size < maxSize)
                {
                    result.Add(dir);
                }
                result.AddRange(dir.GetAllSubdirectoriesLowerThan(maxSize));
            }
            return result;
        }

        public List<MyDirectory> GetAllSubdirectoriesHigherThan(int minSize)
        {
            var result = new List<MyDirectory>();
            foreach (var dir in Subdirectories.Values)
            {
                if (dir.Size > minSize)
                {
                    result.Add(dir);
                }
                result.AddRange(dir.GetAllSubdirectoriesHigherThan(minSize));
            }
            return result;
        }

        public MyDirectory GetOrCreateSubdirectory(ReadOnlySpan<char> directoryNameSpan)
        {
            var directoryName = directoryNameSpan.ToString();
            if (Subdirectories.ContainsKey(directoryName))
            {
                return Subdirectories[directoryName];
            }
            Subdirectories.Add(directoryName, new MyDirectory() { Name = directoryName, Parent = this });
            return Subdirectories[directoryName];
        }

        public MyFile GetOrCreateFile(ReadOnlySpan<char> fileNameSpan, ReadOnlySpan<char> fileSizeSpan)
        {
            var fileName = fileNameSpan.ToString();
            if (Files.ContainsKey(fileName))
            {
                return Files[fileName];
            }
            Files.Add(fileName, new MyFile() { Name = fileName, Size = int.Parse(fileSizeSpan), Directory = this });
            return Files[fileName];
        }
    }
}
