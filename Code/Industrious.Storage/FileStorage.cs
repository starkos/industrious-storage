namespace Industrious.Storage;

public class FileStorage
{
	public static IFileStorageProvider Connect(FileStorageProvider provider)
	{
		switch (provider)
		{
		case FileStorageProvider.Icloud:
			return IcloudStorageProvider.Connect();

		default:
			throw new ArgumentOutOfRangeException(nameof(provider), provider, null);
		}
	}
}
