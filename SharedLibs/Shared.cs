namespace SharedLibs
{
    public static class Shared
    {
        public static ReadOnlySpan<string> LoadFromFileAsSpan(string fileName)
        {
            return File.ReadAllLines(fileName).AsSpan();
        }
    }
}