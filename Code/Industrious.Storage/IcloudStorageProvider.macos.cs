namespace Industrious.Storage;

internal class IcloudStorageProvider : IFileStorageProvider
{
	private readonly String _documentsPath;


	private IcloudStorageProvider(String documentsPath)
	{
		_documentsPath = documentsPath;
	}


	public static IFileStorageProvider Connect()
	{
		// TODO make this async, could take a long time to set up

		// TODO check ubiquityIdentityToken first to see if iCloud is even available
		// https://developer.apple.com/documentation/foundation/nsfilemanager/1408036-ubiquityidentitytoken

		// Make sure that the container has been set up correctly. For the moment I'm hardcoding
		// this to act as a public documents folder, assuming that I'll need to do something
		// similar for other providers when I get that far. Might change it up later. I'm not
		// entirely sure the ways this could go wrong yet, perhaps first launch with no network
		// connection?

		var containerUrl = NSFileManager.DefaultManager.GetUrlForUbiquityContainer(null);
		if (containerUrl == null)
			throw new FileNotFoundException("Could not locate application's ubiquity container");

		var documentsPath = Path.Join(containerUrl.Path, "Documents");
		if (!NSFileManager.DefaultManager.FileExists(documentsPath))
			throw new FileNotFoundException("The application's ubiquity container does not exist");

		return new IcloudStorageProvider(documentsPath);
	}


	// File enumeration logic
	// var directoryInfo = new DirectoryInfo(documentsPath!);
	// foreach (var fileInfo in directoryInfo.EnumerateFiles())
	// {
	// 	var name = fileInfo.Name;
	// 	var attributes = fileInfo.Attributes;
	// 	var lastModified = fileInfo.LastWriteTimeUtc;
	// }
}
