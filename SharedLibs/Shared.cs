namespace SharedLibs
{
    public static class Shared
    {
        public static ReadOnlySpan<string> LoadFromFileAsSpan(string fileName)
        {
            try
            {
                return File.ReadAllLines(fileName).AsSpan();
            }
            catch
            {
                return new string[0];
            }
        }
    }
}
