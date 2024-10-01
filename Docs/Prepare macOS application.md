# Prepare macOS application

- Application must be signed as a Mac Developer for distribution through the Mac App Store

### Set a initial bundle version

In order to "activate" the new container, the bundle's version number will need to incremented, and incremented again each time the container's metadata is changed and needs to be refreshed. Make sure the version listed in `Info.plist` can be safely incremented while still following whatever conventions you intend to follow.

```xml
<key>CFBundleShortVersionString</key>
<string>0.0.1</string>
```

### Add the required entitlements

In `Entitlements.plist`; replace occurrences of `com.mycompany.MyApplication` with your application's bundle identifier. Note that [you cannot use `$(CFBundleIdentifier)` here][1] (I think).

```xml
<?xml version="1.0" encoding="UTF-8" ?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
	<key>com.apple.developer.icloud-container-identifiers</key>
	<array>
		<string>iCloud.com.mycompany.MyApplication</string>
	</array>
	<key>com.apple.developer.icloud-services</key>
	<array>
		<string>CloudDocuments</string>
	</array>
	<key>com.apple.developer.ubiquity-container-identifiers</key>
	<array>
		<string>iCloud.com.mycompany.MyApplication</string>
	</array>
</dict>
</plist>
```

### Register the ubiquitous container

In `Info.plist`, replacing identifiers with your own.

```xml
<dict>
	<key>iCloud.com.mycompany.MyApplication</key>
	<dict>
		<key>NSUbiquitousContainerIsDocumentScopePublic</key>
		<true/>
		<key>NSUbiquitousContainerName</key>
		<string>MyApplication</string>
		<key>NSUbiquitousContainerSupportedFolderLevels</key>
		<string>Any</string>
	</dict>
</dict>
```

### Enable iCloud capabilities in Developer Portal

In [Apple Developer Certificates, Identifiers & Profiles][2], register the application's bundle identifier if you haven't already, then enable the iCloud capability.

Then, under ..., register a new iCloud Container with the same ubiquity container identifier (`iCloud.com.mycompany.MyApplication`) and associate it with the iCloud capability of the application identifier. _(Maybe do this first instead?)_

[1]: https://stackoverflow.com/questions/25203697/exposing-an-apps-ubiquitous-container-to-icloud-drive-in-ios-8
[2]: https://developer.apple.com/account/resources/certificates/list
