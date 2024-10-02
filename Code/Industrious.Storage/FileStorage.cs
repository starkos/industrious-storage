namespace Industrious.Storage;

public static class FileStorage
{
	public static IFileStorageProvider Connect(FileStorageProvider provider)
	{
		return provider switch
		{
			FileStorageProvider.Icloud => IcloudStorageProvider.Connect(),
			_ => throw new ArgumentOutOfRangeException(nameof(provider), provider, null)
		};
	}
}
